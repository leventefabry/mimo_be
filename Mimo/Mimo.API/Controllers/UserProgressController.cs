using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mimo.Application.Contracts;

namespace Mimo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProgressController(IUserLessonProgressService userLessonProgressService) : ControllerBase
{
    [Authorize]
    [HttpGet(Name = "GetUserProgress")]
    public async Task<ActionResult> GetUserProgress(CancellationToken token = default)
    {
        return Ok(await userLessonProgressService.GetUserProgress(token));
    }
}