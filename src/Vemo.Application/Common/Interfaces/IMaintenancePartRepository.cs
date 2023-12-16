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
}