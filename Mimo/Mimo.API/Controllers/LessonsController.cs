using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mimo.Application.Contracts;

namespace Mimo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonsController(ILessonService lessonService) : ControllerBase
{
    [Authorize]
    [HttpGet("{lessonId}", Name = "GetLesson")]
    public async Task<ActionResult> GetLessonById(Guid lessonId, CancellationToken token = default)
    {
        var lesson = await lessonService.GetLessonByIdAsync(lessonId, token);
        if (lesson is null)
        {
            return NotFound();
        }

        return Ok(lesson);
    }

    [Authorize]
    [HttpPost("finish/{lessonId}", Name = "FinishLesson")]
    public async Task<ActionResult> FinishLesson(Guid lessonId, CancellationToken token = default)
    {
        var result = await lessonService.FinishLessonAsync(lessonId, token);
        return result.IsSuccess
            ? result.Value.Any() ? Ok(result.Value) : NoContent()
            : BadRequest("Error during finishing the lesson");
    }
}