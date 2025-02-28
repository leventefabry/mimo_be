namespace Mimo.Domain.Entities;

public class UserLessonProgress
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }

    public User User { get; set; } = null!;
    
    public Guid LessonId { get; set; }

    public Lesson Lesson { get; set; } = null!;

    public int NumberOfAttempts { get; set; } = 0;
    
    public DateTimeOffset DateStarted { get; set; } = DateTimeOffset.Now;
    
    public DateTimeOffset? DateFinished { get; set; }
}