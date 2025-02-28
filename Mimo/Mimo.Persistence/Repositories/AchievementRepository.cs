using Microsoft.EntityFrameworkCore;
using Mimo.Domain.Contracts;
using Mimo.Domain.Entities;
using Mimo.Persistence.Data;

namespace Mimo.Persistence.Repositories;

public class AchievementRepository(MimoDbContext context) : RepositoryBase<Achievement>(context), IAchievementRepository
{
    public async Task<IEnumerable<Achievement>> GetAllAchievementsAsync(bool trackChanges,
        CancellationToken token = default) =>
        await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync(token);
}