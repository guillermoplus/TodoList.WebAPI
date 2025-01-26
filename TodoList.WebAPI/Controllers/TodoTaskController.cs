using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.DTO;
using TodoList.Application.UseCases;

namespace TodoList.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TodoTaskController(
    ILogger<TodoTaskController> logger,
    GetTodoTaskByIdUseCase getTodoTaskByIdUseCase,
    GetAllTodoTaskUseCase getAllTodoTaskUseCase,
    CreateTodoTaskUseCase createTodoTaskUseCase,
    UpdateTodoTaskUseCase updateTodoTaskUseCase,
    DeleteTodoTaskUseCase deleteTodoTaskUseCase,
    MarkTaskAsCompletedUseCase markTaskAsCompletedUseCase) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var task = await getTodoTaskByIdUseCase.ExecuteAsync(id);
        return Ok(task);
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await getAllTodoTaskUseCase.ExecuteAsync();
        return Ok(tasks);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateTodoTaskRequest todoTask)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var task = createTodoTaskUseCase.ExecuteAsync(todoTask);
        return Ok(task);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTodoTaskRequest todoTask)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var task = await updateTodoTaskUseCase.ExecuteAsync(id, todoTask);
        return Ok(task);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deletedTask = await deleteTodoTaskUseCase.ExecuteAsync(id);
        return Ok(deletedTask);
    }

    [HttpPatch("{id:guid}/Complete")]
    public async Task<IActionResult> Complete(Guid id)
    {
        var completedTask = await markTaskAsCompletedUseCase.ExecuteAsync(id);
        return Ok(completedTask);
    }
}