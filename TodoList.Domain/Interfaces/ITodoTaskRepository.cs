using TodoList.Domain.Entities;

namespace TodoList.Domain.Interfaces;

public interface ITodoTaskRepository
{
    Task<TodoTask?> GetByIdAsync(Guid id);
    Task<IEnumerable<TodoTask>> GetAllAsync();
    Task<TodoTask> AddAsync(TodoTask task);
    Task<TodoTask> UpdateAsync(TodoTask task);
    Task<bool> DeleteAsync(Guid id);
}