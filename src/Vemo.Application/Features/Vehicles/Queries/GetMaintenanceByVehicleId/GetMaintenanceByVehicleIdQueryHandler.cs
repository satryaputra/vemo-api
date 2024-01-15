using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Vehicles.Queries.GetMaintenanceByVehicleId;

/// <summary>
/// GetMaintenanceByVehicleIdQueryHandler
/// </summary>
public class GetMaintenanceByVehicleIdQueryHandler : IRequestHandler<GetMaintenanceByVehicleIdQuery, object>
{
    private readonly IMaintenanceVehicleRepository _maintenanceVehicleRepository;
    private readonly IMaintenancePartRepository _maintenancePartRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="GetMaintenanceByVehicleIdQueryHandler"/> class.
    /// </summary>
    /// <param name="maintenanceVehicleRepository"></param>
    /// <param name="maintenancePartRepository"></param>
    public GetMaintenanceByVehicleIdQueryHandler(IMaintenanceVehicleRepository maintenanceVehicleRepository,
        IMaintenancePartRepository maintenancePartRepository)
    {
        _maintenanceVehicleRepository = maintenanceVehicleRepository;
        _maintenancePartRepository = maintenancePartRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<object> Handle(GetMaintenanceByVehicleIdQuery request, CancellationToken cancellationToken)
    {
        var maintenanceVehicle =
            await _maintenanceVehicleRepository.GetMaintenanceVehicleByVehicleIdAsync(request.VehicleId,
                cancellationToken) ?? throw new NotFoundException("Maintenance vehicle tidak ditemukan");

        var maintenanceParts =
            await _maintenancePartRepository.GetMaintenancePartsByMaintenanceVehicleIdAsync(maintenanceVehicle.Id,
                cancellationToken);

        return new { maintenanceVehicle, maintenanceParts };
    }
}