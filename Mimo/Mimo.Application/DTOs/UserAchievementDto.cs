namespace Mimo.Application.DTOs;

public readonly record struct UserAchievementDto
{
    public Guid AchievementId { get; init; }
    
    public string AchievementName { get; init; }
    
    public bool Achieved { get; init; }
    
    public int Threshold { get; init; }
    
    public int Progress { get; init; }
}