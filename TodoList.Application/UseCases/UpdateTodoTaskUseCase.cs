using TodoList.Application.DTO;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.UseCases;

public class UpdateTodoTaskUseCase(ITodoTaskRepository todoTaskRepository)
{
    public async Task<TodoTask> ExecuteAsync(Guid id, UpdateTodoTaskRequest request)
    {
        var task = await todoTaskRepository.GetByIdAsync(id);
        if (task is null)
        {
            throw new Exception("Task not found");
        }

        task.Update(request.Title, request.Description, request.DueDate);
        await todoTaskRepository.UpdateAsync(task);
        return task;
    }
}