using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Common.Interfaces;

/// <summary>
/// IMaintenanceVehicleRepository
/// </summary>
public interface IMaintenanceVehicleRepository
{
    /// <summary>
    /// AddMaintenanceVehicleAsync
    /// </summary>
    /// <param name="newMaintenanceVehicle"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddMaintenanceVehicleAsync(MaintenanceVehicle newMaintenanceVehicle, CancellationToken cancellationToken);

    /// <summary>
    /// RequestMaintenance
    /// </summary>
    /// <returns></returns>
    string RequestMaintenance();
}