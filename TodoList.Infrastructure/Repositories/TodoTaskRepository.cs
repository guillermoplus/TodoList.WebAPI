using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;
using TodoList.Infrastructure.Persistence;

namespace TodoList.Infrastructure.Repositories;

public class TodoTaskRepository(TodoListDbContext context) : ITodoTaskRepository
{
    public async Task<TodoTask?> GetByIdAsync(Guid id)
    {
        return await context.TodoTasks.FindAsync(id);
    }

    public async Task<IEnumerable<TodoTask>> GetAllAsync()
    {
        return await context.TodoTasks.ToListAsync();
    }

    public async Task<TodoTask> AddAsync(TodoTask task)
    {
        var result = await context.TodoTasks.AddAsync(task);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<TodoTask> UpdateAsync(TodoTask task)
    {
        var result = context.TodoTasks.Update(task);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var task = await context.TodoTasks.FindAsync(id);
        if (task is null)
        {
            return false;
        }

        context.TodoTasks.Remove(task);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }
}