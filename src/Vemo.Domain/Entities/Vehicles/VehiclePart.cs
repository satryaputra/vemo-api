using Vemo.Domain.Common;

namespace Vemo.Domain.Entities.Vehicles;

/// <summary>
/// VehiclePart
/// </summary>
public class VehiclePart : BaseAuditableEntity
{
    /// <summary>
    /// Gets or sets Name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets AgeInMonth
    /// </summary>
    public int AgeInMonth { get; set; }
}