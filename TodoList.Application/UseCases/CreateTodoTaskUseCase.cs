using TodoList.Application.DTO;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.UseCases;

public class CreateTodoTaskUseCase(ITodoTaskRepository todoTaskRepository)
{
    public async Task<TodoTaskResponse> ExecuteAsync(CreateTodoTaskRequest request)
    {
        var task = await todoTaskRepository.AddAsync(new TodoTask(request.Title, request.Description, request.DueDate));
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