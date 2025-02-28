using Mimo.Application.DTOs;

namespace Mimo.Application.Services.AchievementFactory;

public abstract class BaseAchievementValidator
{
    protected int GetFinishedChapters(IEnumerable<Guid> userLessons, IEnumerable<ChapterTreeDto> chapters)
    {
        var finishedChapters = chapters
            .Select(chapter => userLessons.ToHashSet().IsSupersetOf(chapter.LessonIds))
            .Count(isFinished => isFinished);
        return finishedChapters;
    }
}