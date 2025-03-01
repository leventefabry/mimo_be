using Mimo.Application.DTOs;

namespace Mimo.Application.Services.AchievementFactory;

public abstract class BaseAchievementValidator
{
    protected int GetNumberOfFinishedChapters(IEnumerable<Guid> userLessons, IEnumerable<ChapterTreeDto> chapters)
    {
        var finishedChapters = chapters
            .Select(chapter => userLessons.ToHashSet().IsSupersetOf(chapter.LessonIds))
            .Count(isFinished => isFinished);
        return finishedChapters;
    }

    protected int GetNumberOfFinishedLessons(IEnumerable<Guid> userLessons, IEnumerable<ChapterTreeDto> chapters)
    {
        var finishedChapters = chapters
            .SelectMany(chapter => chapter.LessonIds)
            .Count(userLessons.Contains);
        return finishedChapters;
    }
}