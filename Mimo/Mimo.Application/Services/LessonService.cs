using Mimo.Application.Contracts;
using Mimo.Application.DTOs;
using Mimo.Application.Mappers;
using Mimo.Domain.Contracts;

namespace Mimo.Application.Services;

public class LessonService(
    IRepositoryManager repositoryManager,
    IUserAccessor userAccessor,
    IUserLessonProgressService userLessonProgressService
    ) : ILessonService
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
    
    public async Task<bool> FinishLessonAsync(Guid lessonId, CancellationToken token = default)
    {
        var lesson = await repositoryManager.Lesson.GetLessonByIdAsync(lessonId, false, token);
        if (lesson is null)
        {
            return false;
        }
        
        // some validation about the lesson has been finished successfully
        
        // TODO: check achievements
        
        var userId = userAccessor.GetUserId();
        return await userLessonProgressService.FinishUserLessonProgress(userId!.Value, lessonId, token);
    }
}