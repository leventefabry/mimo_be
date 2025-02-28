using Microsoft.AspNetCore.Mvc;
using Mimo.Application.Contracts;

namespace Mimo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController(ICourseService courseService) : ControllerBase
{
    [HttpGet(Name = "GetCourses")]
    public async Task<ActionResult> GetCourses(CancellationToken token)
    {
        var courses = await courseService.GetAllCoursesAsync(token);
        return Ok(courses);
    }
}