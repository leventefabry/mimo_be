using Mimo.Application.DTOs;
using Mimo.Domain.DTOs;

namespace Mimo.Application.Mappers;

public static class CourseTreeMapper
{
    public static CourseTreeDto ToCourseTreeDto(this CourseTreeQueryDto course) => new()
    {
        Id = course.Id,
        Chapters = course.Chapters.ToChapterTreeDtoList(),
    };
    
    public static ChapterTreeDto ToChapterTreeDto(this ChapterTreeQueryDto chapter) => new()
    {
        Id = chapter.Id,
        LessonIds = chapter.LessonIds
    };
    
    public static HashSet<CourseTreeDto> ToCourseTreeDtoList(this IEnumerable<CourseTreeQueryDto> courses) =>
        courses.Select(c => c.ToCourseTreeDto()).ToHashSet();
    
    public static HashSet<ChapterTreeDto> ToChapterTreeDtoList(this IEnumerable<ChapterTreeQueryDto> chapters) =>
        chapters.Select(c => c.ToChapterTreeDto()).ToHashSet();
}