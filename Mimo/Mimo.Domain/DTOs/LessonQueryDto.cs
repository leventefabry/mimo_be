namespace Mimo.Domain.DTOs;

public readonly record struct LessonQueryDto
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }
    
    public int Order { get; init; }
    
    public string Description { get; init; }
}