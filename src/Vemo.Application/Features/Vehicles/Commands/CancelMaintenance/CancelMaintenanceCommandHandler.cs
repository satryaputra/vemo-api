using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Notifications;

namespace Vemo.Application.Features.Vehicles.Commands.CancelMaintenance;

internal sealed class CancelMaintenanceCommandHandler : IRequestHandler<CancelMaintenanceCommand, object>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMaintenanceVehicleRepository _maintenanceVehicleRepository;
    private readonly INotificationRepository _notificationRepository;

    public CancelMaintenanceCommandHandler(IVehicleRepository vehicleRepository,
        IMaintenanceVehicleRepository maintenanceVehicleRepository, INotificationRepository notificationRepository)
    {
        _vehicleRepository = vehicleRepository;
        _maintenanceVehicleRepository = maintenanceVehicleRepository;
        _notificationRepository = notificationRepository;
    }

    public async Task<object> Handle(CancelMaintenanceCommand request, CancellationToken cancellationToken)
    {
        var maintenanceVehicle =
            await _maintenanceVehicleRepository.GetMaintenanceVehicleByIdAsync(request.MaintenanceVehicleId,
                cancellationToken);

        var vehicle = await _vehicleRepository.GetVehicleByIdAsync(maintenanceVehicle.VehicleId, cancellationToken);

        await _maintenanceVehicleRepository.UpdateStatusAsync(maintenanceVehicle, request.Status, cancellationToken);
        await _vehicleRepository.UpdateMaintenanceStatusAsync(vehicle, request.Status, cancellationToken);

        await _notificationRepository.AddNotificationAsync(new Notification
        {
            Title = $"Maintenance {vehicle.Name}",
            Description = request.Description,
            Category = "admin",
            UserId = vehicle.UserId,
            Read = false,
        }, cancellationToken);

        return new GenericResponseDto("Berhasil membatalkan perawatan kendaraan");
    }
}