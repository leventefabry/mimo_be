using Mimo.Application.Contracts.AchievementValidators;
using Mimo.Domain.Common;

namespace Mimo.Application.Services.AchievementFactory;

public class AchievementFactory(IEnumerable<IAchievementValidator> validators) : IAchievementFactory
{
    public IAchievementValidator GetAchievementValidator(AchievementType type)
    {
        var validator = validators.FirstOrDefault(v => v.GetAchievementType.Equals(type));
        if (validator == null)
        {
            throw new ArgumentNullException(nameof(AchievementFactory), "Achievement validator not found");
        }

        return validator;
    }
}

public interface IAchievementFactory
{
    IAchievementValidator GetAchievementValidator(AchievementType type);
}