namespace Mimo.Application.DTOs;

public readonly record struct LessonWithCopyDto
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }
    
    public string Description { get; init; }
    
    public string LessonsCopy { get; init; }

    public int Order { get; init; }
}