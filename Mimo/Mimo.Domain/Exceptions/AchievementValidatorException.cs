namespace Mimo.Domain.Exceptions;

public class AchievementValidatorException : Exception
{
    public AchievementValidatorException()
    {
    }

    public AchievementValidatorException(string message) : base(message)
    {
    }
}