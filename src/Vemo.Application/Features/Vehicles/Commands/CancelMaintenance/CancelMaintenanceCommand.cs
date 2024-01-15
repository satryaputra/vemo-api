namespace Vemo.Application.Features.Vehicles.Commands.CancelMaintenance;

public class CancelMaintenanceCommand : IRequest<object>
{
    public Guid MaintenanceVehicleId { get; set; }

    public string Status { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}