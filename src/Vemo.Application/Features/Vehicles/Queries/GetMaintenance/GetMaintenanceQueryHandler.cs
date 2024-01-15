using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Vehicles.Queries.GetMaintenance;

/// <summary>
/// GetMaintenanceQueryHandler
/// </summary>
internal sealed class GetMaintenanceQueryHandler : IRequestHandler<GetMaintenanceQuery, object>
{
    private readonly IMaintenanceVehicleRepository _maintenanceVehicleRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="GetMaintenanceQueryHandler"/> class.
    /// </summary>
    /// <param name="maintenanceVehicleRepository"></param>
    public GetMaintenanceQueryHandler(IMaintenanceVehicleRepository maintenanceVehicleRepository)
    {
        _maintenanceVehicleRepository = maintenanceVehicleRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<object> Handle(GetMaintenanceQuery request, CancellationToken cancellationToken)
    {
        return await _maintenanceVehicleRepository.GetMaintenanceVehicleByVehicleIdAsync(request.VehicleId,
            cancellationToken);
    }
}