namespace Mimo.Domain.DTOs;

public readonly record struct CourseQueryDto
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }
    
    public string Description { get; init; }

    public IEnumerable<ChapterQueryDto> Chapters { get; init; }
}