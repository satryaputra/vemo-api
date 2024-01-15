using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Common.Interfaces;

/// <summary>
/// IMaintenancePartRepository
/// </summary>
public interface IMaintenancePartRepository
{
    /// <summary>
    /// AddMaintenancePartAsync
    /// </summary>
    /// <param name="newMaintenancePart"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddMaintenancePartAsync(MaintenancePart newMaintenancePart, CancellationToken cancellationToken);

    /// <summary>
    /// UpdateMaintenancePriceAsync
    /// </summary>
    /// <param name="maintenancePart"></param>
    /// <param name="newPrice"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateMaintenancePriceAsync(MaintenancePart maintenancePart, double newPrice,
        CancellationToken cancellationToken);

    /// <summary>
    /// GetMaintenancePartById
    /// </summary>
    /// <param name="maintenancePartId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MaintenancePart> GetMaintenancePartById(Guid maintenancePartId, CancellationToken cancellationToken);

    /// <summary>
    /// GetMaintenancePartByIdAsync
    /// </summary>
    /// <param name="maintenanceVehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<MaintenancePart>> GetMaintenancePartsByMaintenanceVehicleIdAsync(Guid maintenanceVehicleId,
        CancellationToken cancellationToken);
}