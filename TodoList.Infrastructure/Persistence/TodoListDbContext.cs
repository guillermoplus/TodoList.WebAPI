using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;

namespace TodoList.Infrastructure.Persistence;

public class TodoListDbContext(DbContextOptions<TodoListDbContext> options) : DbContext(options)
{
    public DbSet<TodoTask> TodoTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TodoTask>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Title).IsRequired().HasMaxLength(100);
            entity.Property(t => t.IsCompleted).HasDefaultValue(false);
        });
    }
}