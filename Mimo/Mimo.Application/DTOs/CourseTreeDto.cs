namespace Mimo.Application.DTOs;

public readonly record struct CourseTreeDto
{
    public Guid Id { get; init; }
    
    public HashSet<ChapterTreeDto> Chapters { get; init; }
}