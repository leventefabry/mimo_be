namespace Mimo.Domain.Contracts;

public interface IUserAchievementRepository
{
    void CreateUserAchievement(Guid userId, Guid achievementId);
}