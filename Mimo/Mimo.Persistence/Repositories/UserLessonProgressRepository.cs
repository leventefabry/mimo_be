using Microsoft.EntityFrameworkCore;
using Mimo.Domain.Contracts;
using Mimo.Domain.DTOs;
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

    public async Task<IEnumerable<UserLessonProgressQueryDto>> GetProgressByUserIdIdAsync(Guid userId,
        CancellationToken token = default)
    {
        return await FindByCondition(l => l.UserId.Equals(userId), false)
            .Select(l => new UserLessonProgressQueryDto
            {
                LessonName = l.Lesson.Name,
                LessonId = l.LessonId,
                NumberOfAttempts = l.NumberOfAttempts,
                DateStarted = l.DateStarted,
                DateFinished = l.DateFinished,
            })
            .ToListAsync(token);
    }

    public async Task<IEnumerable<Guid>> GetFinishedLessonGuidsByUserIdIdAsync(Guid userId,
        CancellationToken token = default)
    {
        return await FindByCondition(l => l.UserId.Equals(userId) && l.DateFinished.HasValue, false)
            .Select(l => l.LessonId)
            .ToListAsync(token);
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