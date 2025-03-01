using Mimo.Application.Contracts;
using Mimo.Application.DTOs;
using Mimo.Application.Mappers;
using Mimo.Domain.Common;
using Mimo.Domain.Contracts;

namespace Mimo.Application.Services;

public class LessonService(
    IRepositoryManager repositoryManager,
    IUserAccessor userAccessor,
    IUserLessonProgressService userLessonProgressService,
    IAchievementService achievementService) : ILessonService
{
    public async Task<LessonWithCopyDto?> GetLessonByIdAsync(Guid lessonId, CancellationToken token = default)
    {
        var lesson = await repositoryManager.Lesson.GetLessonByIdAsync(lessonId, false, token);
        if (lesson is null)
        {
            return null;
        }

        var userId = userAccessor.GetUserId();
        await userLessonProgressService.TrackUserLessonProgress(userId!.Value, lessonId, token);

        return lesson.ToLessonWithCopyDto();
    }

    public async Task<Result<IEnumerable<NewAchievementDto>>> FinishLessonAsync(Guid lessonId,
        CancellationToken token = default)
    {
        var lesson = await repositoryManager.Lesson.GetLessonByIdAsync(lessonId, false, token);
        if (lesson is null)
        {
            return Result<IEnumerable<NewAchievementDto>>.Failure("The lesson was not found")!;
        }

        // some validation about the lesson has been finished successfully
        var finished = true;

        var userId = userAccessor.GetUserId();
        var result = await userLessonProgressService.FinishUserLessonProgress(userId!.Value, lessonId, finished, token);
        if (!result)
        {
            return Result<IEnumerable<NewAchievementDto>>.Failure("Error while finishing the lesson")!;
        }

        var newAchievements = await achievementService.CheckAchievementsAsync(userId!.Value, token);
        return Result<IEnumerable<NewAchievementDto>>.Success(newAchievements);
    }
}