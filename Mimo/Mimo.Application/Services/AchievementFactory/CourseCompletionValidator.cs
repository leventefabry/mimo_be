using Mimo.Application.Contracts.AchievementValidators;
using Mimo.Application.DTOs;
using Mimo.Domain.Common;
using Mimo.Domain.Entities;
using Mimo.Domain.Exceptions;

namespace Mimo.Application.Services.AchievementFactory;

public class CourseCompletionValidator : BaseAchievementValidator, IAchievementValidator
{
    public AchievementType GetAchievementType => AchievementType.CourseCompletion;

    public AchievementCheck Check(Achievement achievement, IEnumerable<CourseTreeDto> courseTrees,
        IEnumerable<Guid> userLessons)
    {
        CourseTreeDto? course = courseTrees.FirstOrDefault(c => c.Id.Equals(achievement.CourseId));
        if (course is null)
        {
            throw new CourseNotFoundException("Course was not found");
        }

        var chaptersCount = course.Value.Chapters.Count;
        var lessonsCount = course.Value.Chapters.SelectMany(ch => ch.LessonIds).Count();
        var userLessonsList = userLessons.ToList();
        var finishedChapters = GetNumberOfFinishedChapters(userLessonsList, course.Value.Chapters);
        var numberOfFinishedLessons = GetNumberOfFinishedLessons(userLessonsList, course.Value.Chapters);
        
        var achieved = chaptersCount == finishedChapters;

        return new AchievementCheck
        {
            Achieved = achieved,
            Threshold = lessonsCount,
            Progress = numberOfFinishedLessons
        };
    }
}