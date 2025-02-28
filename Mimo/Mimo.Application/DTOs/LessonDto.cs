namespace Mimo.Application.DTOs;

public readonly record struct LessonDto
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }
    
    public string Description { get; init; }

    public int Order { get; init; }
}