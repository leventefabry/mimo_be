using Mimo.Application.Contracts.AchievementValidators;
using Mimo.Application.DTOs;
using Mimo.Domain.Common;
using Mimo.Domain.Entities;

namespace Mimo.Application.Services.AchievementFactory;

public class ChapterCountValidator : BaseAchievementValidator, IAchievementValidator
{
    public AchievementType GetAchievementType => AchievementType.ChapterCount;

    public bool Valid(Achievement achievement, IEnumerable<CourseTreeDto> courseTrees, IEnumerable<Guid> userLessons)
    {
        var chapters = courseTrees.SelectMany(c => c.Chapters);
        var finishedChapters = GetFinishedChapters(userLessons, chapters);
        return finishedChapters >= achievement.Count;
    }
}