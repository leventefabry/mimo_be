using Microsoft.EntityFrameworkCore;
using Mimo.Domain.Contracts;
using Mimo.Domain.DTOs;
using Mimo.Domain.Entities;
using Mimo.Persistence.Data;

namespace Mimo.Persistence.Repositories;

public class UserRepository(MimoDbContext context) : RepositoryBase<User>(context), IUserRepository
{
    public async Task<User?> GetUserByUsernameAsync(string username, bool trackChanges,
        CancellationToken token = default) =>
        await FindByCondition(c => c.Username.Equals(username), trackChanges)
            .SingleOrDefaultAsync(token);

    public async Task<UserProgressAndAchievementsQueryDto?> GetUserProgressAndAchievementsAsync(Guid id,
        CancellationToken token = default)
    {
        return await FindByCondition(u => u.Id.Equals(id), false)
            .Select(u => new UserProgressAndAchievementsQueryDto
            {
                LessonIds = u.LessonProgresses.Where(l => l.DateFinished.HasValue).Select(l => l.LessonId),
                AchievementsIds = u.Achievements.Select(a => a.Id)
            }).SingleOrDefaultAsync(token);
    }
}