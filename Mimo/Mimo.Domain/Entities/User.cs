namespace Mimo.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    
    public string Username { get; set; } = string.Empty;
    
    public string PasswordHash { get; set; } = string.Empty;
    
    public ICollection<UserAchievement> UserAchievements { get; set; } = [];
    public ICollection<Achievement> Achievements { get; set; } = [];
    
    public ICollection<UserLessonProgress> LessonProgresses { get; set; } = [];
    public ICollection<Lesson> Lessons { get; set; } = [];
}