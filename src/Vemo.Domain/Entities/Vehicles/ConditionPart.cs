using System.Text.Json.Serialization;
using Vemo.Domain.Common;

namespace Vemo.Domain.Entities.Vehicles;

/// <summary>
/// MaintenancePart
/// </summary>
public class ConditionPart : BaseEntity
{
    /// <summary>
    /// Gets or sets LastMaintenance
    /// </summary>
    public DateTime LastMaintenance { get; set; }
    
    [JsonIgnore]
    public Vehicle Vehicle { get; set; } = null!;

    /// <summary>
    /// Gets or sets VehicleId
    /// </summary>
    public Guid VehicleId { get; set; }
    
    [JsonIgnore]
    public Part Part { get; set; } = null!;

    /// <summary>
    /// Gets or sets VehiclePartId
    /// </summary>
    public Guid PartId { get; set; }
}