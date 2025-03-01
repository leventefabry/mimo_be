using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mimo.Application.Contracts;
using Mimo.Application.DTOs;

namespace Mimo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonsController(ILessonService lessonService) : ControllerBase
{
    /// <summary>
    /// Get lesson
    /// </summary>
    /// <remarks>
    /// Marks the lesson as started
    /// </remarks>
    /// <param name="lessonId">ID of the lesson</param>
    /// <param name="token">Cancellation token</param>
    /// <returns>The lesson with the lesson's copy</returns> 
    [Authorize]
    [HttpGet("{lessonId:guid}", Name = "GetLesson")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<LessonWithCopyDto>> GetLessonById(Guid lessonId, CancellationToken token = default)
    {
        var lesson = await lessonService.GetLessonByIdAsync(lessonId, token);
        if (lesson is null)
        {
            return NotFound();
        }

        return Ok(lesson);
    }

    /// <summary>
    /// Finishes the lesson
    /// </summary>
    /// <remarks>
    /// Finishes the lesson and checks if achievement has been completed
    /// </remarks>
    /// <param name="lessonId">ID of the lesson</param>
    /// <param name="token">Cancellation token</param>
    /// <returns>The lesson with the lesson's copy</returns> 
    [Authorize]
    [HttpPost("finish/{lessonId:guid}", Name = "FinishLesson")]
    [ProducesResponseType(200)]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public async Task<ActionResult<IEnumerable<NewAchievementDto>>> FinishLesson(Guid lessonId, CancellationToken token = default)
    {
        var result = await lessonService.FinishLessonAsync(lessonId, token);
        return result.IsSuccess
            ? result.Value.Any() ? Ok(result.Value) : NoContent()
            : BadRequest("Error during finishing the lesson");
    }
}