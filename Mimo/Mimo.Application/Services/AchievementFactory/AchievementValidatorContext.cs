using Mimo.Application.Contracts.AchievementValidators;
using Mimo.Application.DTOs;
using Mimo.Domain.Entities;
using Mimo.Domain.Exceptions;

namespace Mimo.Application.Services.AchievementFactory;

public class AchievementValidatorContext
{
    private IAchievementValidator? _validator;

    public void SetValidator(IAchievementValidator validator)
    {
        _validator = validator;
    }

    public AchievementCheck Check(Achievement achievement, IEnumerable<CourseTreeDto> courseTrees,
        IEnumerable<Guid> userLessons)
    {
        if (_validator is null)
        {
            throw new AchievementValidatorException("The Validator cannot be null.");
        }
        
        return _validator.Check(achievement, courseTrees, userLessons);
    }
}