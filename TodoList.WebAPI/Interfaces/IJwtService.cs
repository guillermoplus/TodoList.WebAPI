namespace TodoList.WebAPI.Interfaces;

public interface IJwtService
{
    string GenerateToken(string userId);
}