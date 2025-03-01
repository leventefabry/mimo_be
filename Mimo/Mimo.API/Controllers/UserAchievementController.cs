using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mimo.Application.Contracts;
using Mimo.Application.DTOs;

namespace Mimo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserAchievementController(IAchievementService achievementService) : ControllerBase
{
    /// <summary>
    /// Get the logged-in user's achievements
    /// </summary>
    /// <param name="token">Cancellation token</param>
    /// <returns>The achievements</returns> 
    [Authorize]
    [HttpGet(Name = "GetUserAchievement")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<IEnumerable<UserAchievementDto>>> GetUserAchievement(CancellationToken token = default)
    {
        return Ok(await achievementService.CheckUsersAchievementsAsync(token));
    }
}