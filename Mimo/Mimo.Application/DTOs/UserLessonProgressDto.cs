namespace Mimo.Application.DTOs;

public readonly record struct UserLessonProgressDto
{
    public string LessonName { get; init; }
    
    public Guid LessonId { get; init; }

    public int NumberOfAttempts { get; init; }
    
    public string DateStarted { get; init; }
    
    public string DateFinished { get; init; }
    
    public bool Completed { get; init; } 
}