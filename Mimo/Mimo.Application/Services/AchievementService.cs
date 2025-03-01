using Mimo.Application.Contracts;
using Mimo.Application.DTOs;
using Mimo.Application.Mappers;
using Mimo.Application.Services.AchievementFactory;
using Mimo.Domain.Contracts;
using Mimo.Domain.Entities;
using Mimo.Domain.Exceptions;

namespace Mimo.Application.Services;

public class AchievementService(
    IRepositoryManager repositoryManager,
    IUserAccessor userAccessor,
    IAchievementFactory achievementFactory) : IAchievementService
{
    public async Task<IEnumerable<NewAchievementDto>> CheckAchievementsAsync(Guid userId,
        CancellationToken token = default)
    {
        var userData = await repositoryManager.User.GetUserProgressAndAchievementsAsync(userId, token);
        if (!userData.HasValue)
        {
            throw new UserNotFoundException("User was not found");
        }

        var achievements =
            await repositoryManager.Achievement.GetNotFinishedAchievementsAsync(userData.Value.AchievementsIds, token);

        var courseTrees = await repositoryManager.Course.GetAllCourseTreesAsync(token);
        var mappedCourseTrees = courseTrees.ToCourseTreeDtoList();

        var newAchievements = new List<Achievement>();
        var context = new AchievementValidatorContext();
        foreach (var achievement in achievements)
        {
            var validator = achievementFactory.GetAchievementValidator(achievement.AchievementType);
            context.SetValidator(validator);
            var result = context.Check(achievement, mappedCourseTrees, userData.Value.LessonIds);

            if (!result.Achieved) continue;
            
            newAchievements.Add(achievement);
            repositoryManager.UserAchievement.CreateUserAchievement(userId, achievement.Id);
        }

        if (newAchievements.Count != 0)
        {
            await repositoryManager.SaveAsync(token);
        }

        return newAchievements.ToNewAchievementDtoList();
    }

    public async Task<IEnumerable<UserAchievementDto>> CheckUsersAchievementsAsync(CancellationToken token = default)
    {
        var userId = userAccessor.GetUserId();
        var userData = await repositoryManager.User.GetUserProgressAndAchievementsAsync(userId!.Value, token);
        if (!userData.HasValue)
        {
            throw new UserNotFoundException("User was not found");
        }
        
        var achievements = await repositoryManager.Achievement.GetAllAchievementsAsync(false, token);
        
        var courseTrees = await repositoryManager.Course.GetAllCourseTreesAsync(token);
        var mappedCourseTrees = courseTrees.ToCourseTreeDtoList();

        var userAchievements = new List<UserAchievementDto>();
        var context = new AchievementValidatorContext();
        foreach (var achievement in achievements)
        {
            var validator = achievementFactory.GetAchievementValidator(achievement.AchievementType);
            context.SetValidator(validator);
            var result = context.Check(achievement, mappedCourseTrees, userData.Value.LessonIds);
            
            userAchievements.Add(new UserAchievementDto
            {
                AchievementId = achievement.Id,
                AchievementName = achievement.Name,
                Achieved = result.Achieved,
                Threshold = result.Threshold,
                Progress = result.Progress,
            });
        }

        return userAchievements;
    }
}