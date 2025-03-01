namespace Mimo.Application.DTOs;

public readonly record struct AchievementCheck
{
    public bool Achieved { get; init; }
    
    public int Threshold { get; init; }
    
    public int Progress { get; init; }
}