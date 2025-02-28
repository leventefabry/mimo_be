namespace Mimo.Infrastructure.Auth.DTOs;

public readonly record struct UserDto
{
    public string Username { get; init; }
    
    public string Password { get; init; }
}