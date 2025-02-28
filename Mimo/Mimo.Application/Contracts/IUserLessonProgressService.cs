namespace Mimo.Application.Contracts;

public interface IUserLessonProgressService
{
    Task TrackUserLessonProgress(Guid userId, Guid lessonId, CancellationToken token = default);

    Task<bool> FinishUserLessonProgress(Guid userId, Guid lessonId, bool finished, CancellationToken token = default);
}