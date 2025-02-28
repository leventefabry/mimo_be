using Mimo.Domain.Contracts;
using Mimo.Domain.Entities;
using Mimo.Persistence.Data;

namespace Mimo.Persistence.Repositories;

public class UserAchievementRepository(MimoDbContext context)
    : RepositoryBase<UserAchievement>(context), IUserAchievementRepository
{
    public void CreateUserAchievement(Guid userId, Guid achievementId)
    {
        var userAchievement = new UserAchievement
        {
            UserId = userId,
            AchievementId = achievementId,
        };

        Create(userAchievement);
    }
}