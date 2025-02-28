using Microsoft.AspNetCore.Mvc;
using Mimo.Infrastructure.Auth.Contracts;
using Mimo.Infrastructure.Auth.DTOs;
using Mimo.Infrastructure.Auth.Responses;

namespace Mimo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
    {
        var result = await authService.LoginAsync(request);
        if (result is null)
        {
            return BadRequest("Invalid username or password.");
        }

        return Ok(result);
    }
}