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
    /// Gets or sets UpdateStatusAsync
    /// </summary>
    /// <param name="maintenanceVehicle"></param>
    /// <param name="status"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateStatusAsync(MaintenanceVehicle maintenanceVehicle, string status, CancellationToken cancellationToken);
    
    /// <summary>
    /// GetMaintenanceVehicleByIdAsync
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MaintenanceVehicle> GetMaintenanceVehicleByIdAsync(Guid id,
        CancellationToken cancellationToken);

    /// <summary>
    /// GetMaintenanceVehicleById
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<MaintenanceVehicle>> GetMaintenanceVehicleByVehicleIdAsync(Guid vehicleId,
        CancellationToken cancellationToken);

    /// <summary>
    /// GetRequestByVehicleIdAsync
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MaintenanceVehicle?> GetRequestByVehicleIdAsync(Guid vehicleId, CancellationToken cancellationToken);

    /// <summary>
    /// RequestMaintenance
    /// </summary>
    /// <returns></returns>
    string RequestMaintenance();

    /// <summary>
    /// Gets or sets ServiceMaintenance
    /// </summary>
    /// <returns></returns>
    string ServiceMaintenance();
}