using Mimo.Application.DTOs;
using Mimo.Domain.Entities;

namespace Mimo.Application.Mappers;

public static class CourseMapper
{
    public static CourseDto ToCourseDto(this Course course) => new CourseDto
    {
        Id = course.Id,
        Name = course.Name,
        Description = course.Description
    };

    public static IEnumerable<CourseDto> MapCourses(this IEnumerable<Course> courses) =>
        courses.Select(c => c.ToCourseDto());
}