using System.ComponentModel.DataAnnotations;
using Mimo.Domain.Common;
using Mimo.Domain.Common.Interfaces;

namespace Mimo.Domain.Entities;

public class Chapter : BaseEntity, IOrderable
{
    [MaxLength(250)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    public int Order { get; set; }

    public Guid CourseId { get; set; }
    
    public Course Course { get; set; } = null!;
    
    public ICollection<Lesson> Lessons { get; set; } = [];
}