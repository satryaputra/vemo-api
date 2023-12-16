namespace Vemo.Application.Features.Vehicles.Commands.RequestMaintenance;

/// <summary>
/// RequestMaintenanceCommand
/// </summary>
public class RequestMaintenanceCommand
{
    /// <summary>
    /// Gets or sets Contact
    /// </summary>
    public string Contact { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Description
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets UserId
    /// </summary>
    public Guid VehicleId { get; set; }
    
    /// <summary>
    /// Gets or sets VehiclePartsId
    /// </summary>
    public List<Guid> VehiclePartsId { get; set; } = null!;
}