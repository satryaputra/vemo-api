namespace Vemo.Application.Features.Vehicles.Commands.AddPartVehicle;

/// <summary>
/// AddVehiclePartCommand
/// </summary>
public class AddPartVehicleCommand : IRequest<Guid>
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
}