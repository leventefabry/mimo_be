using Mimo.Application.DTOs;
using Mimo.Domain.DTOs;

namespace Mimo.Application.Mappers;

public static class ChapterMapper
{
    public static ChapterDto ToChapterDto(this ChapterQueryDto chapter) => new()
    {
        Id = chapter.Id,
        Name = chapter.Name,
        Description = chapter.Description,
        Order = chapter.Order,
        Lessons = chapter.Lessons.ToLessonDtoList(),
    };
    
    public static IEnumerable<ChapterDto> ToChapterDtoList(this IEnumerable<ChapterQueryDto> chapters) => 
        chapters.Select(c => c.ToChapterDto());
}