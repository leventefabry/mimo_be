using Microsoft.EntityFrameworkCore;
using Mimo.Domain.Contracts;
using Mimo.Domain.Entities;
using Mimo.Persistence.Data;

namespace Mimo.Persistence.Repositories;

public class UserLessonProgressRepository(MimoDbContext context)
    : RepositoryBase<UserLessonProgress>(context), IUserLessonProgressRepository
{
    public async Task<UserLessonProgress?> GetUserLessonProgressByLessonIdAsync(Guid userId, Guid lessonId,
        CancellationToken token = default)
    {
        return await FindByCondition(l => l.LessonId.Equals(lessonId) && l.UserId.Equals(userId), true)
            .SingleOrDefaultAsync(token);
    }

    public void CreateUserLessonProgress(Guid userId, Guid lessonId)
    {
        var userLessonProgress = new UserLessonProgress
        {
            UserId = userId,
            LessonId = lessonId,
            NumberOfAttempts = 1,
        };

        Create(userLessonProgress);
    }
}