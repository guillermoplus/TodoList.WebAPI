using TodoList.Application.DTO;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.UseCases;

public class UpdateTodoTaskUseCase(ITodoTaskRepository todoTaskRepository)
{
    public async Task<TodoTaskResponse> ExecuteAsync(Guid id, UpdateTodoTaskRequest request)
    {
        var task = await todoTaskRepository.GetByIdAsync(id);
        if (task is null)
        {
            throw new Exception("Task not found");
        }

        task.Update(request.Title, request.Description, request.DueDate);
        await todoTaskRepository.UpdateAsync(task);
        return new TodoTaskResponse()
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            IsCompleted = task.IsCompleted,
            CreatedAt = task.CreatedAt,
            DueDate = task.DueDate,
            CompletedAt = task.CompletedAt
        };
    }
}