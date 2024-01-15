using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Features.Vehicles.Commands.DoneMaintenance;

internal sealed class DoneMaintenanceCommandHandler : IRequestHandler<DoneMaintenanceCommand, object>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMaintenanceVehicleRepository _maintenanceVehicleRepository;
    private readonly IMaintenancePartRepository _maintenancePartRepository;
    private readonly IConditionPartRepository _conditionPartRepository;

    public DoneMaintenanceCommandHandler(IMaintenanceVehicleRepository maintenanceVehicleRepository,
        IVehicleRepository vehicleRepository, IMaintenancePartRepository maintenancePartRepository,
        IConditionPartRepository conditionPartRepository)
    {
        _maintenanceVehicleRepository = maintenanceVehicleRepository;
        _vehicleRepository = vehicleRepository;
        _maintenancePartRepository = maintenancePartRepository;
        _conditionPartRepository = conditionPartRepository;
    }

    public async Task<object> Handle(DoneMaintenanceCommand request, CancellationToken cancellationToken)
    {
        var maintenanceVehicle =
            await _maintenanceVehicleRepository.GetMaintenanceVehicleByIdAsync(request.MaintenanceVehicleId,
                cancellationToken);

        var vehicle = await _vehicleRepository.GetVehicleByIdAsync(maintenanceVehicle.VehicleId, cancellationToken);

        foreach (var maintenancePartId in request.MaintenancePartIds)
        {
            var maintenancePart =
                await _maintenancePartRepository.GetMaintenancePartById(maintenancePartId, cancellationToken);
            var conditionPart =
                await _conditionPartRepository.GetConditionPartByPartIdAsync(maintenancePart.PartId, cancellationToken);
            await _conditionPartRepository.UpdateLastMaintenanceToNowAsync(conditionPart, cancellationToken);
        }

        await _maintenanceVehicleRepository.UpdateStatusAsync(maintenanceVehicle, "done", cancellationToken);
        await _vehicleRepository.UpdateMaintenanceStatusAsync(vehicle, "done", cancellationToken);

        return new GenericResponseDto("Berhasil service kendaraan");
    }
}