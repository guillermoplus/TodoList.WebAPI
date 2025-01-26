using TodoList.Application.DTO;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.UseCases;

public class MarkTaskAsCompletedUseCase(ITodoTaskRepository todoTaskRepository)
{
    public async Task<TodoTaskResponse> ExecuteAsync(Guid id)
    {
        var task = await todoTaskRepository.GetByIdAsync(id);
        if (task is null)
        {
            throw new KeyNotFoundException("Task not found");
        }

        task.MarkAsCompleted();
        await todoTaskRepository.UpdateAsync(task);
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