using Mimo.Application.Contracts.AchievementValidators;
using Mimo.Application.DTOs;
using Mimo.Domain.Common;
using Mimo.Domain.Entities;

namespace Mimo.Application.Services.AchievementFactory;

public class LessonCountValidator : BaseAchievementValidator, IAchievementValidator
{
    public AchievementType GetAchievementType => AchievementType.LessonCount;

    public AchievementCheck Check(Achievement achievement, IEnumerable<CourseTreeDto> courseTrees, IEnumerable<Guid> userLessons)
    {
        var currentProgress = userLessons.ToList().Count;
        var achieved = currentProgress >= achievement.Count;
        
        return new AchievementCheck
        {
            Achieved = achieved,
            Threshold = achievement.Count,
            Progress = currentProgress
        };
    }
}