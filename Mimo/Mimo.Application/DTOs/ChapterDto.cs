namespace Mimo.Application.DTOs;

public readonly record struct ChapterDto
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }
    
    public string Description { get; init; }

    public int Order { get; init; }
    
    public IEnumerable<LessonDto> Lessons { get; init; }
}