namespace Mimo.Domain.DTOs;

public readonly record struct CourseTreeQueryDto
{
    public Guid Id { get; init; }
    
    public HashSet<ChapterTreeQueryDto> Chapters { get; init; }
}