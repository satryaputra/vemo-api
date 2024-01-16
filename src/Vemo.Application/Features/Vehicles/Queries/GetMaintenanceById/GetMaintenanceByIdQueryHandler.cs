using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Vehicles.Queries.GetMaintenanceById;

/// <summary>
/// GetMaintenanceByIdQueryHandler
/// </summary>
internal sealed class GetMaintenanceByIdQueryHandler : IRequestHandler<GetMaintenanceByIdQuery, object>
{
    private readonly IMaintenanceVehicleRepository _maintenanceVehicleRepository;
    private readonly IMaintenancePartRepository _maintenancePartRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="GetMaintenanceByIdQueryHandler"/> class.
    /// </summary>
    /// <param name="maintenanceVehicleRepository"></param>
    /// <param name="maintenancePartRepository"></param>
    public GetMaintenanceByIdQueryHandler(IMaintenanceVehicleRepository maintenanceVehicleRepository,
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
    /// <exception cref="NotFoundException"></exception>
    public async Task<object> Handle(GetMaintenanceByIdQuery request, CancellationToken cancellationToken)
    {
        var maintenanceVehicle =
            await _maintenanceVehicleRepository.GetMaintenanceVehicleByIdAsync(request.MaintenanceId,
                cancellationToken) ?? throw new NotFoundException("Maintenance vehicle tidak ditemukan");

        var maintenanceParts =
            await _maintenancePartRepository.GetMaintenancePartsByMaintenanceVehicleIdAsync(maintenanceVehicle.Id,
                cancellationToken);

        return new { maintenanceVehicle, maintenanceParts };
    }
}