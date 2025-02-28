using Microsoft.AspNetCore.Mvc;
using Mimo.Application.Contracts;

namespace Mimo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController(ICourseService courseService) : ControllerBase
{
    [HttpGet(Name = "GetCourses")]
    public async Task<ActionResult> GetCourses(CancellationToken token = default)
    {
        var courses = await courseService.GetAllCoursesAsync(token);
        return Ok(courses);
    }
    
    [HttpGet("{courseId}", Name = "GetCourse")]
    public async Task<ActionResult> GetCourseById(Guid courseId, CancellationToken token = default)
    {
        var course = await courseService.GetCourseByIdAsync(courseId, token);
        if (course is null)
        {
            return NotFound();
        }
        
        return Ok(course);
    }
}