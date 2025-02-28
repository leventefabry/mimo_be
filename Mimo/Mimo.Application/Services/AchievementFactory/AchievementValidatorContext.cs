using Mimo.Application.Contracts.AchievementValidators;
using Mimo.Application.DTOs;
using Mimo.Domain.Entities;

namespace Mimo.Application.Services.AchievementFactory;

public class AchievementValidatorContext
{
    private IAchievementValidator? _validator;

    public void SetValidator(IAchievementValidator validator)
    {
        _validator = validator;
    }

    public bool Validate(Achievement achievement, IEnumerable<CourseTreeDto> courseTrees,
        IEnumerable<Guid> userLessons)
    {
        if (_validator is null)
        {
            throw new ArgumentNullException(nameof(_validator), "The Validator cannot be null.");
        }
        
        return _validator.Valid(achievement, courseTrees, userLessons);
    }
}