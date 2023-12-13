using System.Text.Json.Serialization;
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

    /// <summary>
    /// Gets or sets VehiclePartMaintenanceSchedules
    /// </summary>
    [JsonIgnore]
    public List<VehiclePartCondition> VehiclePartConditions { get; set; } = null!;

    /// <summary>
    /// Gets or sets VehiclePartMaintenanceHistories
    /// </summary>
    [JsonIgnore]
    public List<VehiclePartMaintenanceHistory>? VehiclePartMaintenanceHistories { get; set; }
}