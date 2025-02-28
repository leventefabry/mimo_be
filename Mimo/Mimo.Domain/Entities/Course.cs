using System.ComponentModel.DataAnnotations;
using Mimo.Domain.Common;

namespace Mimo.Domain.Entities;

public class Course : BaseEntity
{
    [MaxLength(250)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    public ICollection<Chapter> Chapters { get; set; } = [];
}