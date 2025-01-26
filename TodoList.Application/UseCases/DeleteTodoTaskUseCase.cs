using TodoList.Application.DTO;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.UseCases;

public class DeleteTodoTaskUseCase(ITodoTaskRepository todoTaskRepository)
{
    public async Task<TodoTaskResponse> ExecuteAsync(Guid id)
    {
        var task = await todoTaskRepository.GetByIdAsync(id);
        if (task is null)
        {
            throw new KeyNotFoundException("Task not found");
        }

        await todoTaskRepository.DeleteAsync(id);
        return new TodoTaskResponse()
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted,
            CompletedAt = task.CompletedAt,
            DueDate = task.DueDate,
            CreatedAt = task.CreatedAt,
        };
    }
}