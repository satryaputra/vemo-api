using System.Text.Json.Serialization;
using Vemo.Domain.Common;

namespace Vemo.Domain.Entities.Vehicles;

/// <summary>
/// Part
/// </summary>
public class Part : BaseAuditableEntity
{
    /// <summary>
    /// Gets or sets Name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets AgeInMonth
    /// </summary>
    public int AgeInMonth { get; set; }

    /// <summary>
    /// Gets or sets MaintenancePrice
    /// </summary>
    public float MaintenancePrice { get; set; }

    /// <summary>
    /// Gets or sets MaintenanceServicePrice
    /// </summary>
    public float MaintenanceServicePrice { get; set; }

    /// <summary>
    /// Gets or sets VehicleType
    /// </summary>
    public string? VehicleType { get; set; }
    
    [JsonIgnore]
    public List<ConditionPart> ConditionParts { get; set; } = null!;
    
    [JsonIgnore]
    public List<MaintenancePart>? MaintenanceParts { get; set; }
}