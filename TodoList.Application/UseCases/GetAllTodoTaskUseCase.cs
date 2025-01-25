using TodoList.Application.DTO;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.UseCases;

public class GetAllTodoTaskUseCase(ITodoTaskRepository todoTaskRepository)
{
    public async Task<IEnumerable<TodoTaskResponse>> ExecuteAsync()
    {
        var todoTasks = await todoTaskRepository.GetAllAsync();
        return todoTasks.Select(todoTask => new TodoTaskResponse
        {
            Id = todoTask.Id,
            Title = todoTask.Title,
            Description = todoTask.Description,
            IsCompleted = todoTask.IsCompleted,
            CompletedAt = todoTask.CompletedAt,
            CreatedAt = todoTask.CreatedAt,
            DueDate = todoTask.DueDate
        });
    }
}