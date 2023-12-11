namespace Vemo.Domain.Common;

/// <summary>
/// BaseAuditableEntity
/// </summary>
public abstract class BaseAuditableEntity : BaseEntity
{
    /// <summary>
    /// Gets or sets CreatedAt
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Gets or sets UpdatedAt
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}