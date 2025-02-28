using Mimo.Application.DTOs;
using Mimo.Domain.DTOs;
using Mimo.Domain.Entities;

namespace Mimo.Application.Mappers;

public static class CourseMapper
{
    public static CourseDto ToCourseDto(this Course course) => new()
    {
        Id = course.Id,
        Name = course.Name,
        Description = course.Description,
        Chapters = [],
    };
    
    public static CourseDto ToCourseDto(this CourseQueryDto course) => new()
    {
        Id = course.Id,
        Name = course.Name,
        Description = course.Description,
        Chapters = course.Chapters.ToChapterDtoList(),
    };

    public static IEnumerable<CourseDto> ToCourseDtoList(this IEnumerable<Course> courses) =>
        courses.Select(c => c.ToCourseDto());
    
    public static IEnumerable<CourseDto> ToCourseDtoList(this IEnumerable<CourseQueryDto> courses) =>
        courses.Select(c => c.ToCourseDto());
}