using Microsoft.EntityFrameworkCore;
using Mimo.Domain.Contracts;
using Mimo.Domain.Entities;
using Mimo.Persistence.Data;

namespace Mimo.Persistence.Repositories;

public class LessonRepository(MimoDbContext context) : RepositoryBase<Lesson>(context), ILessonRepository
{
    public async Task<Lesson?>
        GetLessonByIdAsync(Guid lessonId, bool trackChanges, CancellationToken token = default) =>
        await FindByCondition(c => c.Id.Equals(lessonId), trackChanges)
            .SingleOrDefaultAsync(token);
}