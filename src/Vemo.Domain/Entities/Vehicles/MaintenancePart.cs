using System.Text.Json.Serialization;
using Vemo.Domain.Common;

namespace Vemo.Domain.Entities.Vehicles;

/// <summary>
/// MaintenancePart
/// </summary>
public class MaintenancePart : BaseAuditableEntity
{
    /// <summary>
    /// Gets or sets MaintenanceFinalPrice
    /// </summary>
    public double MaintenanceFinalPrice { get; set; }

    /// <summary>
    /// Gets or sets MaintenanceServiceFinalPrice
    /// </summary>
    public double MaintenanceServiceFinalPrice { get; set; }
    
    [JsonIgnore]
    public MaintenanceVehicle MaintenanceVehicle { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets MaintenanceVehicleId
    /// </summary>
    public Guid MaintenanceVehicleId { get; set; }
    
    [JsonIgnore]
    public Part Part { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets PartId
    /// </summary>
    public Guid PartId { get; set; }
}