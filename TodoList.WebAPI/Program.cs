using Microsoft.EntityFrameworkCore;
using TodoList.Application.UseCases;
using TodoList.Domain.Interfaces;
using TodoList.Infrastructure.Persistence;
using TodoList.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Database connection
builder.Services.AddDbContext<TodoListDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependencies
builder.Services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();
builder.Services.AddScoped<GetTodoTaskByIdUseCase>();
builder.Services.AddScoped<CreateTodoTaskUseCase>();
builder.Services.AddScoped<UpdateTodoTaskUseCase>();
builder.Services.AddScoped<DeleteTodoTaskUseCase>();
builder.Services.AddScoped<MarkTaskAsCompletedUseCase>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();