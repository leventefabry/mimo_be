namespace Mimo.Domain.DTOs;

public readonly record struct ChapterQueryDto
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }
    
    public string Description { get; init; }

    public int Order { get; init; }

    public IEnumerable<LessonQueryDto> Lessons { get; init; }
}