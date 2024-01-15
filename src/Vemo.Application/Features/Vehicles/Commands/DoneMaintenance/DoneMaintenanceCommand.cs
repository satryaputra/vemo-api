namespace Vemo.Application.Features.Vehicles.Commands.DoneMaintenance;

public class DoneMaintenanceCommand : IRequest<object>
{
    public Guid MaintenanceVehicleId { get; set; }
    
    public List<Guid> MaintenancePartIds { get; set; } = null!;
}