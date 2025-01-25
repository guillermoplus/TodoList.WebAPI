using TodoList.Application.DTO;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.UseCases;

public class CreateTodoTask(ITodoTaskRepository todoTaskRepository)
{
    public async Task<TodoTask> ExecuteAsync(CreateTodoTaskRequest request)
    {
        var task = new TodoTask(request.Title, request.Description, request.DueDate);
        await todoTaskRepository.AddAsync(task);
        var result = new TodoTaskResponse()
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate
        }
        return task;
    }
}