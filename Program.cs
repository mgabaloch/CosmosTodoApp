using Microsoft.Azure.Cosmos;
using System;
using System.Threading.Tasks;

class Program
{
    private static Container? _container;

    static async Task Main()
    {
        string connectionString = "<your-cosmos-connection-string>";
        CosmosClient client = new CosmosClient(connectionString);

        Database db = await client.CreateDatabaseIfNotExistsAsync("TodoDatabase");
        _container = await db.CreateContainerIfNotExistsAsync("TodoContainer", "/id");

        // Example usage
        var todo = new TodoItem { Title = "Learn Cosmos DB", IsComplete = false };
        await AddTodoAsync(todo);

        var fetched = await GetTodoAsync(todo.Id);
        Console.WriteLine($"Fetched: {fetched.Title}, Completed: {fetched.IsComplete}");

        fetched.IsComplete = true;
        await UpdateTodoAsync(fetched);

        var updated = await GetTodoAsync(fetched.Id);
        Console.WriteLine($"Updated: {updated.Title}, Completed: {updated.IsComplete}");

        await DeleteTodoAsync(updated.Id);
        Console.WriteLine("Todo deleted successfully.");
    }

    // Create
    public static async Task AddTodoAsync(TodoItem item)
    {
        await _container.CreateItemAsync(item, new PartitionKey(item.Id));
    }

    // Read
    public static async Task<TodoItem> GetTodoAsync(string id)
    {
        ItemResponse<TodoItem> response = await _container.ReadItemAsync<TodoItem>(id, new PartitionKey(id));
        return response.Resource;
    }

    // Update
    public static async Task UpdateTodoAsync(TodoItem item)
    {
        await _container.UpsertItemAsync(item, new PartitionKey(item.Id));
    }

    // Delete
    public static async Task DeleteTodoAsync(string id)
    {
        await _container.DeleteItemAsync<TodoItem>(id, new PartitionKey(id));
    }
}
