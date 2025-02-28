using Microsoft.AspNetCore.Mvc;
using Mimo.Application.Contracts;
using Mimo.Application.Contracts.Responses;
using Mimo.Application.DTOs;

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