using System.ComponentModel.DataAnnotations;
using Mimo.Domain.Common;

namespace Mimo.Domain.Entities;

public class Achievement : BaseEntity
{
    [MaxLength(250)]
    public string Name { get; set; } = string.Empty;
    
    public AchievementType AchievementType { get; set; }

    public int Count { get; set; }
    
    public Guid? CourseId { get; set; }
    
    public Course? Course { get; set; }

    public ICollection<UserAchievement> UserAchievements { get; set; } = [];
    public ICollection<User> Users { get; set; } = [];
}