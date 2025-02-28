using Mimo.Application.Contracts.AchievementValidators;
using Mimo.Application.DTOs;
using Mimo.Domain.Common;
using Mimo.Domain.Entities;

namespace Mimo.Application.Services.AchievementFactory;

public class CourseCompletionValidator : BaseAchievementValidator, IAchievementValidator
{
    public AchievementType GetAchievementType => AchievementType.CourseCompletion;

    public bool Valid(Achievement achievement, IEnumerable<CourseTreeDto> courseTrees, IEnumerable<Guid> userLessons)
    {
        CourseTreeDto? course = courseTrees.FirstOrDefault(c => c.Id.Equals(achievement.CourseId));
        if (course is null)
        {
            return false;
        }

        var chaptersCount = course.Value.Chapters.Count;
        var finishedChapters = GetFinishedChapters(userLessons, course.Value.Chapters);
        
        return chaptersCount == finishedChapters;
    }
}