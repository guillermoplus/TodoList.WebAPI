using TodoList.Application.DTO;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.UseCases;

public class GetTodoTaskByIdUseCase(ITodoTaskRepository todoTaskRepository)
{
    public async Task<TodoTaskResponse?> ExecuteAsync(Guid id)
    {
        var task = await todoTaskRepository.GetByIdAsync(id);
        if (task == null)
        {
            return null;
        }

        return new TodoTaskResponse()
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            CompletedAt = task.CompletedAt,
            CreatedAt = task.CreatedAt,
            IsCompleted = task.IsCompleted,
        };
    }
}