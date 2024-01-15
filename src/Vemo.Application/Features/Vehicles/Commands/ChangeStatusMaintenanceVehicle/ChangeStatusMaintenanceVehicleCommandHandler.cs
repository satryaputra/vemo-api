using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Vehicles.Commands.ChangeStatusMaintenanceVehicle;

/// <summary>
/// ChangeStatusMaintenanceVehicleCommandHandler
/// </summary>
internal sealed class ChangeStatusMaintenanceVehicleCommandHandler : IRequestHandler<ChangeStatusMaintenanceVehicleCommand, object>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMaintenanceVehicleRepository _maintenanceVehicleRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="ChangeStatusMaintenanceVehicleCommandHandler"/> class.
    /// </summary>
    /// <param name="vehicleRepository"></param>
    /// <param name="maintenanceVehicleRepository"></param>
    public ChangeStatusMaintenanceVehicleCommandHandler(IVehicleRepository vehicleRepository,
        IMaintenanceVehicleRepository maintenanceVehicleRepository)
    {
        _maintenanceVehicleRepository = maintenanceVehicleRepository;
        _vehicleRepository = vehicleRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<object> Handle(ChangeStatusMaintenanceVehicleCommand request, CancellationToken cancellationToken)
    {
        // Get
        var vehicle = await _vehicleRepository.GetVehicleByIdAsync(request.VehicleId, cancellationToken);
        var maintenanceRequest =
            await _maintenanceVehicleRepository.GetRequestByVehicleIdAsync(request.VehicleId, cancellationToken) ??
            throw new NotFoundException("Request Maintenance tidak ditemukan");
        
        // mutate
        await _maintenanceVehicleRepository.UpdateStatusAsync(maintenanceRequest,
            request.Status, cancellationToken);
        await _vehicleRepository.UpdateMaintenanceStatusAsync(vehicle, request.Status, cancellationToken);

        return new GenericResponseDto("Berhasil mengubah status kendaraan menjadi service");
    }
}