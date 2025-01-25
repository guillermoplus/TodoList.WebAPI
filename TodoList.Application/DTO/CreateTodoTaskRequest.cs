﻿namespace TodoList.Application.DTO;

public class CreateTodoTaskRequest
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
}