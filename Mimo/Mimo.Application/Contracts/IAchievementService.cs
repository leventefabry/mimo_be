using Mimo.Application.DTOs;

namespace Mimo.Application.Contracts;

public interface IAchievementService
{
    Task<IEnumerable<NewAchievementDto>> CheckAchievementsAsync(Guid userId, CancellationToken token = default);
}