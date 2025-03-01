using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mimo.Application.Contracts;

namespace Mimo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserAchievementController(IAchievementService achievementService) : ControllerBase
{
    [Authorize]
    [HttpGet(Name = "GetUserAchievement")]
    public async Task<ActionResult> GetUserAchievement(CancellationToken token = default)
    {
        return Ok(await achievementService.CheckUsersAchievementsAsync(token));
    }
}