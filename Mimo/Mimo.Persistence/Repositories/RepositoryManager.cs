using Mimo.Domain.Contracts;
using Mimo.Persistence.Data;

namespace Mimo.Persistence.Repositories;

public class RepositoryManager(MimoDbContext context) : IRepositoryManager
{
    private readonly Lazy<ICourseRepository> _courseRepository = new(() => new CourseRepository(context));

    private readonly Lazy<ILessonRepository> _lessonRepository = new(() => new LessonRepository(context));

    private readonly Lazy<IUserLessonProgressRepository> _progressRepository =
        new(() => new UserLessonProgressRepository(context));

    public ICourseRepository Course => _courseRepository.Value;

    public ILessonRepository Lesson => _lessonRepository.Value;

    public IUserLessonProgressRepository Progress => _progressRepository.Value;

    public async Task SaveAsync(CancellationToken token = default) => await context.SaveChangesAsync(token);
}