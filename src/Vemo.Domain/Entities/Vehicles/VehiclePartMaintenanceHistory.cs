using System.Text.Json.Serialization;
using Vemo.Domain.Common;

namespace Vemo.Domain.Entities.Vehicles;

/// <summary>
/// VehiclePartMaintenanceHistory
/// </summary>
public class VehiclePartMaintenanceHistory : BaseEntity
{
    /// <summary>
    /// Gets or sets Description
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets MaintenanceDate
    /// </summary>
    public DateTime MaintenanceDate { get; set; }

    /// <summary>
    /// Gets or sets MaintenanceFinalPrice
    /// </summary>
    public float MaintenanceFinalPrice { get; set; }

    /// <summary>
    /// Gets or sets MaintenanceServiceFinalPrice
    /// </summary>
    public float MaintenanceServiceFinalPrice { get; set; }

    /// <summary>
    /// Gets or sets Vehicle
    /// </summary>
    [JsonIgnore]
    public Vehicle Vehicle { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets VehicleId
    /// </summary>
    public Guid VehicleId { get; set; }

    /// <summary>
    /// Gets or sets VehiclePart
    /// </summary>
    [JsonIgnore]
    public VehiclePart VehiclePart { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets VehiclePartId
    /// </summary>
    public Guid VehiclePartId { get; set; }
}