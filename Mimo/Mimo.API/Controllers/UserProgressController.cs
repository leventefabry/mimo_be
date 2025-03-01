using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mimo.Application.Contracts;
using Mimo.Application.DTOs;

namespace Mimo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProgressController(IUserLessonProgressService userLessonProgressService) : ControllerBase
{
    /// <summary>
    /// Get the logged-in user's progress
    /// </summary>
    /// <param name="token">Cancellation token</param>
    /// <returns>The lesson's progresses</returns> 
    [Authorize]
    [HttpGet(Name = "GetUserProgress")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<IEnumerable<UserLessonProgressDto>>> GetUserProgress(CancellationToken token = default)
    {
        return Ok(await userLessonProgressService.GetUserProgress(token));
    }
}