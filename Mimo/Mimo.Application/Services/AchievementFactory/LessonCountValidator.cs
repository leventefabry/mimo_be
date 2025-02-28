using Mimo.Application.Contracts.AchievementValidators;
using Mimo.Application.DTOs;
using Mimo.Domain.Common;
using Mimo.Domain.Entities;

namespace Mimo.Application.Services.AchievementFactory;

public class LessonCountValidator : BaseAchievementValidator, IAchievementValidator
{
    public AchievementType GetAchievementType => AchievementType.LessonCount;

    public bool Valid(Achievement achievement, IEnumerable<CourseTreeDto> courseTrees, IEnumerable<Guid> userLessons)
    {
        return userLessons.ToList().Count >= achievement.Count;
    }
}