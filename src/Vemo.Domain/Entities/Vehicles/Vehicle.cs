using System.Text.Json.Serialization;
using Vemo.Domain.Common;
using Vemo.Domain.Entities.Users;

namespace Vemo.Domain.Entities.Vehicles;

/// <summary>
/// Vehicle
/// </summary>
public class Vehicle : BaseAuditableEntity
{
    /// <summary>
    /// Gets or sets Name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets OwnerName
    /// </summary>
    public string OwnerName { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets PurchasingDate
    /// </summary>
    public DateTime PurchasingDate { get; set; }
    
    /// <summary>
    /// Gets or sets LicencePlate
    /// </summary>
    public string LicensePlate { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets Type
    /// </summary>
    public string Type { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets Status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets User
    /// </summary>
    [JsonIgnore]
    public User User { get; set; } = null!;

    /// <summary>
    /// Gets or sets UserId
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets VehiclePartMaintenanceSchedules
    /// </summary>
    [JsonIgnore]
    public List<VehiclePartCondition>? VehiclePartConditions { get; set; }

    /// <summary>
    /// Gets or sets VehiclePartMaintenanceHistories
    /// </summary>
    [JsonIgnore]
    public List<VehiclePartMaintenanceHistory>? VehiclePartMaintenanceHistories { get; set; }
}