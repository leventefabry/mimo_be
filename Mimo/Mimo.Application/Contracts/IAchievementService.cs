namespace Mimo.Application.Contracts;

public interface IAchievementService
{
    Task CheckAchievementsAsync(Guid userId, CancellationToken token = default);
}