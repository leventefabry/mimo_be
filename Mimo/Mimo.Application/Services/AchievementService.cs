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
        var userLessons = await repositoryManager.Progress
            .GetFinishedLessonGuidsByUserIdIdAsync(userId, token);

        var userLessonsList = userLessons.ToList();
        var achievements = await repositoryManager.Achievement.GetAllAchievementsAsync(false, token);
        
        var courseTrees = await repositoryManager.Course.GetAllCourseTreesAsync(token);
        var mappedCourseTrees = courseTrees.ToCourseTreeDtoList();
        
        var context = new AchievementValidatorContext();
        foreach (var achievement in achievements)
        {
            var validator = achievementFactory.GetAchievementValidator(achievement.AchievementType);
            context.SetValidator(validator);
            var valid = context.Validate(achievement, mappedCourseTrees, userLessonsList);
        }
    }
}