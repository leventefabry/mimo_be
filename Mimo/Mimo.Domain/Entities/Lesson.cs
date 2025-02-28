using System.ComponentModel.DataAnnotations;
using Mimo.Domain.Common;
using Mimo.Domain.Common.Interfaces;

namespace Mimo.Domain.Entities;

public class Lesson : BaseEntity, IOrderable
{
    [MaxLength(250)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    public string LessonsCopy { get; set; } = string.Empty;
    
    public int Order { get; set; }
    
    public Guid ChapterId { get; set; }
    
    public Chapter Chapter { get; set; } = null!;
    
    public ICollection<UserLessonProgress> LessonProgresses { get; set; } = [];
    public ICollection<User> Users { get; set; } = [];
}