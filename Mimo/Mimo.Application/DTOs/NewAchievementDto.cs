namespace Mimo.Application.DTOs;

public readonly record struct NewAchievementDto
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }
}