using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Features.Vehicles.Queries.GetMaintenance;

/// <summary>
/// GetMaintenanceQueryHandler
/// </summary>
internal sealed class GetMaintenanceQueryHandler : IRequestHandler<GetMaintenanceQuery, object>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMaintenanceVehicleRepository _maintenanceVehicleRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="GetMaintenanceQueryHandler"/> class.
    /// </summary>
    /// <param name="maintenanceVehicleRepository"></param>
    public GetMaintenanceQueryHandler(IMaintenanceVehicleRepository maintenanceVehicleRepository,
        IVehicleRepository vehicleRepository)
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
    public async Task<object> Handle(GetMaintenanceQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await _vehicleRepository.GetVehiclesByUserIdAsync(request.UserId, cancellationToken);

        var allMaintenanceVehicles = new List<MaintenanceVehicle>();

        foreach (var vehicle in vehicles)
        {
            var maintenanceVehicles = await _maintenanceVehicleRepository.GetMaintenanceVehicleByVehicleIdAsync(
                vehicle.Id,
                cancellationToken);

            allMaintenanceVehicles.AddRange(maintenanceVehicles);
        }

        return allMaintenanceVehicles;
    }
}