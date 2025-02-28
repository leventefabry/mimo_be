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
    public async Task<ActionResult> GetCourseById(Guid lessonId, CancellationToken token = default)
    {
        var lesson = await lessonService.GetLessonByIdAsync(lessonId, token);
        if (lesson is null)
        {
            return NotFound();
        }
        
        return Ok(lesson);
    }
}