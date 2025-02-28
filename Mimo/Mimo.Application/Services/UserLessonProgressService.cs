using Mimo.Application.Contracts;
using Mimo.Domain.Contracts;

namespace Mimo.Application.Services;

public class UserLessonProgressService(IRepositoryManager repositoryManager) : IUserLessonProgressService
{
    public async Task TrackUserLessonProgress(Guid userId, Guid lessonId, CancellationToken token = default)
    {
        var progress = await repositoryManager.Progress.GetUserLessonProgressByLessonIdAsync(userId, lessonId, token);
        if (progress is null)
        {
            repositoryManager.Progress.CreateUserLessonProgress(userId, lessonId);
            await repositoryManager.SaveAsync(token);
            return;
        }

        progress.NumberOfAttempts++;
        progress.DateUpdated = DateTimeOffset.Now;
        await repositoryManager.SaveAsync(token);
    }
    
    public async Task<bool> FinishUserLessonProgress(Guid userId, Guid lessonId, bool finished,
        CancellationToken token = default)
    {
        var progress = await repositoryManager.Progress.GetUserLessonProgressByLessonIdAsync(userId, lessonId, token);
        if (progress is null)
        {
            return false;
        }

        var now = DateTimeOffset.Now;
        progress.DateUpdated = now;

        if (finished)
        {
            progress.DateFinished = now;
        }
        
        await repositoryManager.SaveAsync(token);
        return true;
    }
}