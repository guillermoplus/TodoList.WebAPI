using TodoList.Application.DTO;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.UseCases;

public class DeleteTodoTask(ITodoTaskRepository todoTaskRepository)
{
    public async Task<TodoTaskResponse> ExecuteAsync(Guid id)
    {
        var task = await todoTaskRepository.GetByIdAsync(id);
        if (task is null)
        {
            throw new Exception("Task not found");
        }

        await todoTaskRepository.DeleteAsync(id);
        return task;
    }
}