using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.WebAPI.DTO;
using TodoList.WebAPI.Interfaces;

namespace TodoList.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService;

    public AuthController(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (request.Username == "test" && request.Password == "test")
        {
            var token = _jwtService.GenerateToken("testuser");
            return Ok(new { Token = token });
        }

        return Unauthorized("Invalid credentials");
    }
}