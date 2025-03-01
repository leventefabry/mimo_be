using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mimo.Application.Contracts;
using Mimo.Application.DTOs;

namespace Mimo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController(ICourseService courseService) : ControllerBase
{
    /// <summary>
    /// Get all courses
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>All courses</returns> 
    [HttpGet(Name = "GetCourses")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses(CancellationToken token = default)
    {
        var courses = await courseService.GetAllCoursesAsync(token);
        return Ok(courses);
    }
    
    /// <summary>
    /// Get individual course
    /// </summary>
    /// <remarks>
    /// Sample IDs:
    /// 
    ///     3659ac24-29dd-407a-81f5-ecfe6f924b9b // Swift Programming Fundamentals
    /// 
    ///     6a5011a1-fe1f-47df-9a32-b5346b289391 // JavaScript for Web Development
    /// 
    ///     47111973-d176-4feb-848d-0ea22641c31a // C# and .NET Core Essentials
    /// </remarks>
    /// <param name="courseId">ID of the course</param>
    /// <param name="token">Cancellation token</param>
    /// <returns>The course with all chapters and lessons</returns> 
    [Authorize]
    [HttpGet("{courseId:guid}", Name = "GetCourse")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<CourseDto>> GetCourseById(Guid courseId, CancellationToken token = default)
    {
        var course = await courseService.GetCourseByIdAsync(courseId, token);
        if (course is null)
        {
            return NotFound();
        }
        
        return Ok(course);
    }
}