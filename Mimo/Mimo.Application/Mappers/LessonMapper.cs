using Mimo.Application.DTOs;
using Mimo.Domain.DTOs;
using Mimo.Domain.Entities;

namespace Mimo.Application.Mappers;

public static class LessonMapper
{
    public static LessonWithCopyDto ToLessonWithCopyDto(this Lesson lesson) => new()
    {
        Id = lesson.Id,
        Name = lesson.Name,
        Description = lesson.Description,
        Order = lesson.Order,
        LessonsCopy = lesson.LessonsCopy,
    };
    
    public static LessonDto ToLessonDto(this LessonQueryDto lesson) => new()
    {
        Id = lesson.Id,
        Name = lesson.Name,
        Description = lesson.Description,
        Order = lesson.Order,
    };
    
    public static IEnumerable<LessonDto> ToLessonDtoList(this IEnumerable<LessonQueryDto> lessons) =>
        lessons.Select(c => c.ToLessonDto());
}