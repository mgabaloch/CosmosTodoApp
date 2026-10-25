using Microsoft.Azure.Cosmos;

class Program
{
    static async Task Main()
    {
        string connectionString = "<your-cosmos-connection-string>";
        CosmosClient client = new CosmosClient(connectionString);

        Database db = await client.CreateDatabaseIfNotExistsAsync("TodoDatabase");
        Container container = await db.CreateContainerIfNotExistsAsync("TodoContainer", "/id");

        var todo = new TodoItem { Title = "Learn Cosmos DB", IsComplete = false };
        await container.CreateItemAsync(todo, new PartitionKey(todo.Id));

        var fetched = await container.ReadItemAsync<TodoItem>(todo.Id, new PartitionKey(todo.Id));
        Console.WriteLine($"Fetched: {fetched.Resource.Title}, Completed: {fetched.Resource.IsComplete}");
    }
}
