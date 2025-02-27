using Microsoft.AspNetCore.Mvc;

namespace Mimo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    [HttpGet(Name = "GetCourses")]
    public ActionResult GetCourses()
    {
        return Ok("Courses Test");
    }
}