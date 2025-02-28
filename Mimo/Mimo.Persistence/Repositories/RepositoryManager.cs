using Mimo.Domain.Contracts;
using Mimo.Persistence.Data;

namespace Mimo.Persistence.Repositories;

public class RepositoryManager(MimoDbContext context) : IRepositoryManager
{
    private readonly Lazy<ICourseRepository> _courseRepository = new(() => new CourseRepository(context));

    private readonly Lazy<ILessonRepository> _lessonRepository = new(() => new LessonRepository(context));

    private readonly Lazy<IUserLessonProgressRepository> _progressRepository =
        new(() => new UserLessonProgressRepository(context));

    private readonly Lazy<IAchievementRepository>
        _achievementRepository = new(() => new AchievementRepository(context));

    private readonly Lazy<IUserAchievementRepository> _userAchievementRepository =
        new(() => new UserAchievementRepository(context));


    public ICourseRepository Course => _courseRepository.Value;

    public ILessonRepository Lesson => _lessonRepository.Value;

    public IUserLessonProgressRepository Progress => _progressRepository.Value;

    public IAchievementRepository Achievement => _achievementRepository.Value;

    public IUserAchievementRepository UserAchievement => _userAchievementRepository.Value;

    public async Task SaveAsync(CancellationToken token = default) => await context.SaveChangesAsync(token);
}