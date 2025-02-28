namespace Mimo.Domain.DTOs;

public readonly record struct UserLessonProgressQueryDto
{
    public string LessonName { get; init; }
    public Guid LessonId { get; init; }

    public int NumberOfAttempts { get; init; }
    
    public DateTimeOffset DateStarted { get; init; }
    
    public DateTimeOffset? DateFinished { get; init; }
}