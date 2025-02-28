using Mimo.Application.Contracts;
using Mimo.Application.Mappers;
using Mimo.Application.Services.AchievementFactory;
using Mimo.Domain.Contracts;

namespace Mimo.Application.Services;

public class AchievementService(
    IRepositoryManager repositoryManager,
    IAchievementFactory achievementFactory) : IAchievementService
{
    public async Task CheckAchievementsAsync(Guid userId, CancellationToken token = default)
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

        var context = new AchievementValidatorContext();
        foreach (var achievement in achievements)
        {
            var validator = achievementFactory.GetAchievementValidator(achievement.AchievementType);
            context.SetValidator(validator);
            var valid = context.Validate(achievement, mappedCourseTrees, userData.Value.LessonIds);
        }
    }
}