using Microsoft.AspNetCore.Mvc;
using Mimo.Application.Contracts;
using Mimo.Application.Contracts.Responses;
using Mimo.Application.DTOs;

namespace Mimo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    /// <summary>
    /// Login endpoint
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST api/Auth
    ///     {        
    ///       "username": "john_doe",
    ///       "password": "password"
    ///     }
    ///     OR
    ///     {        
    ///       "username": "jane_doe",
    ///       "password": "password"
    ///     }
    /// </remarks>
    /// <param name="request">Contains username and password</param>
    /// <returns>The bearer token</returns> 
    [HttpPost("login")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
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