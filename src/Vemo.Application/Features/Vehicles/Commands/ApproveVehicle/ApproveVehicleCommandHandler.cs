using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Notifications;

namespace Vemo.Application.Features.Vehicles.Commands.ApproveVehicle;

/// <summary>
/// ApproveVehicleCommandHandler
/// </summary>
internal sealed class ApproveVehicleCommandHandler : IRequestHandler<ApproveVehicleCommand, GenericResponseDto>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly INotificationRepository _notificationRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="ApproveVehicleCommandHandler"/> class.
    /// </summary>
    /// <param name="vehicleRepository"></param>
    /// <param name="notificationRepository"></param>
    public ApproveVehicleCommandHandler(
        IVehicleRepository vehicleRepository, 
        INotificationRepository notificationRepository)
    {
        _vehicleRepository = vehicleRepository;
        _notificationRepository = notificationRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GenericResponseDto> Handle(ApproveVehicleCommand request, CancellationToken cancellationToken)
    {
        await _vehicleRepository.ApproveVehicleAsync(request.VehicleId, cancellationToken);
        var vehicle = await _vehicleRepository.GetVehicleByIdAsync(request.VehicleId, cancellationToken);
        
        // Notification
        var notification = new Notification()
        {
            Title = "Pendaftaran Kendaraan",
            Description = $"Selamat! Kendaraan {vehicle.Name} anda dengan Plat Nomor {vehicle.LicensePlate} telah disetujui oleh admin",
            UserId = vehicle.UserId
        };

        await _notificationRepository.AddNotificationAsync(notification, cancellationToken);
        
        return new GenericResponseDto("Kendaraan telah disetujui");
    }
}