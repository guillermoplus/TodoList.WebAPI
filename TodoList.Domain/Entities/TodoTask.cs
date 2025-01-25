namespace TodoList.Domain.Entities;

public class TodoTask
{
    public Guid Id { get; init; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; init; }
    public DateTime? DueDate { get; set; }
    public DateTime? CompletedAt { get; set; }

    public TodoTask(string title, string? description, DateTime? dueDate)
    {
        Id = Guid.NewGuid();
        Title = string.IsNullOrWhiteSpace(title)
            ? throw new ArgumentException("Title cannot be empty.")
            : title;
        Description = description;
        DueDate = dueDate;
        CreatedAt = DateTime.UtcNow;
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
        CompletedAt = DateTime.UtcNow;
    }

    public void Update(string title, string? description, DateTime? dueDate)
    {
        Title = string.IsNullOrWhiteSpace(title)
            ? throw new ArgumentException("Title cannot be empty.")
            : title;
        Description = description;
        DueDate = dueDate;
    }
}