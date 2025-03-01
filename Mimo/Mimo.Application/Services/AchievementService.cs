using Mimo.Application.Contracts;
using Mimo.Application.DTOs;
using Mimo.Application.Mappers;
using Mimo.Application.Services.AchievementFactory;
using Mimo.Domain.Contracts;
using Mimo.Domain.Entities;

namespace Mimo.Application.Services;

public class AchievementService(
    IRepositoryManager repositoryManager,
    IAchievementFactory achievementFactory) : IAchievementService
{
    public async Task<IEnumerable<NewAchievementDto>> CheckAchievementsAsync(Guid userId, CancellationToken token = default)
    {
        var userData = await repositoryManager.User.GetUserProgressAndAchievementsAsync(userId, token);
        if (!userData.HasValue)
        {
            throw new ArgumentNullException(nameof(userData), "User was not found");
        }

        var achievements =
            await repositoryManager.Achievement.GetAchievementsExceptAsync(userData.Value.AchievementsIds, token);

        var courseTrees = await repositoryManager.Course.GetAllCourseTreesAsync(token);
        var mappedCourseTrees = courseTrees.ToCourseTreeDtoList();

        var newAchievements = new List<Achievement>();
        var context = new AchievementValidatorContext();
        foreach (var achievement in achievements)
        {
            var validator = achievementFactory.GetAchievementValidator(achievement.AchievementType);
            context.SetValidator(validator);
            var valid = context.Validate(achievement, mappedCourseTrees, userData.Value.LessonIds);

            if (valid)
            {
                newAchievements.Add(achievement);
                repositoryManager.UserAchievement.CreateUserAchievement(userId, achievement.Id);
            }
        }

        if (newAchievements.Any())
        {
            await repositoryManager.SaveAsync(token);
        }
        
        return newAchievements.ToNewAchievementDtoList();
    }
}