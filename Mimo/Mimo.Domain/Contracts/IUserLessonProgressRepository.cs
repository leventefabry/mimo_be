using Mimo.Domain.Entities;

namespace Mimo.Domain.Contracts;

public interface IUserLessonProgressRepository
{
    Task<UserLessonProgress?> GetUserLessonProgressByLessonIdAsync(Guid userId, Guid lessonId,
        CancellationToken token = default);

    void CreateUserLessonProgress(Guid userId, Guid lessonId);
}