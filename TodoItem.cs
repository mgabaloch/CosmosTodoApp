public class TodoItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; }
    public bool IsComplete { get; set; }
}
