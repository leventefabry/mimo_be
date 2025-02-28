namespace Mimo.Domain.DTOs;

public readonly record struct UserProgressAndAchievementsQueryDto
{
    public IEnumerable<Guid> LessonIds { get; init; }
    
    public IEnumerable<Guid> AchievementsIds { get; init; }
}