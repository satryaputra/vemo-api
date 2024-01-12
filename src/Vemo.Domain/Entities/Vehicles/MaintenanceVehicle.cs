using System.Text.Json.Serialization;
using Vemo.Domain.Common;

namespace Vemo.Domain.Entities.Vehicles;

/// <summary>
/// MaintenanceVehicle
/// </summary>
public class MaintenanceVehicle : BaseAuditableEntity
{
    /// <summary>
    /// Gets or sets Ticket
    /// </summary>
    public string Ticket { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets Contact
    /// </summary>
    public string Contact { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Description
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Status
    /// </summary>
    public string Status { get; set; } = string.Empty;
    
    [JsonIgnore] 
    public Vehicle Vehicle { get; set; } = null!;

    /// <summary>
    /// Gets or sets VehicleId
    /// </summary>
    public Guid VehicleId { get; set; }

    [JsonIgnore]
    public List<MaintenancePart> MaintenanceParts { get; set; } = null!;
}