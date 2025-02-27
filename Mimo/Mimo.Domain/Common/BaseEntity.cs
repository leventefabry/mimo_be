namespace Mimo.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    
    public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;
   
    public DateTimeOffset? DateUpdated { get; set; }
    
    public DateTimeOffset? DateDeleted { get; set; }
    
    public bool IsDeleted { get; set; } = false;
}