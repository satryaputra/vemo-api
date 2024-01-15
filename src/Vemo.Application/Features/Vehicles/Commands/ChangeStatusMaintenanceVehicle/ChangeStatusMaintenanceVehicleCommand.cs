namespace Vemo.Application.Features.Vehicles.Commands.ChangeStatusMaintenanceVehicle;

/// <summary>
/// ChangeStatusMaintenanceVehicleCommand
/// </summary>
public class ChangeStatusMaintenanceVehicleCommand : IRequest<object>
{
    /// <summary>
    /// Gets or sets VehicleId
    /// </summary>
    public Guid VehicleId { get; set; }

    /// <summary>
    /// Gets or sets Status
    /// </summary>
    public string Status { get; set; } = string.Empty;
}