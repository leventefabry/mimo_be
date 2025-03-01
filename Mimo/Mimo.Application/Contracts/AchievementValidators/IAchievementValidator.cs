using Mimo.Application.DTOs;
using Mimo.Domain.Common;
using Mimo.Domain.Entities;

namespace Mimo.Application.Contracts.AchievementValidators;

public interface IAchievementValidator
{
    AchievementType GetAchievementType { get; }

    AchievementCheck Check(Achievement achievement, IEnumerable<CourseTreeDto> courseTrees,
        IEnumerable<Guid> userLessons);
}