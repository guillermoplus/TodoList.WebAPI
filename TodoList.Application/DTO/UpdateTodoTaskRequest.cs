namespace TodoList.Application.DTO;

public class UpdateTodoTaskRequest
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
}