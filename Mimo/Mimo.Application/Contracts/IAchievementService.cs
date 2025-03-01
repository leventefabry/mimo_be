using Mimo.Application.DTOs;

namespace Mimo.Application.Contracts;

public interface IAchievementService
{
    Task<IEnumerable<NewAchievementDto>> CheckAchievementsAsync(Guid userId, CancellationToken token = default);

    Task<IEnumerable<UserAchievementDto>> CheckUsersAchievementsAsync(CancellationToken token = default);
}