using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Common.Interfaces;

/// <summary>
/// IConditionPartRepository
/// </summary>
public interface IConditionPartRepository
{
    /// <summary>
    /// AddConditionPartAsync
    /// </summary>
    /// <param name="conditionPart"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddConditionPartAsync(ConditionPart conditionPart, CancellationToken cancellationToken);

    /// <summary>
    /// UpdateLastMaintenanceToNowAsync
    /// </summary>
    /// <param name="conditionPart"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateLastMaintenanceToNowAsync(ConditionPart conditionPart, CancellationToken cancellationToken);

    /// <summary>
    /// UpdateLastMaintenance
    /// </summary>
    /// <param name="conditionId"></param>
    /// <param name="newLastMaintenancePart"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateLastMaintenanceAsync(Guid conditionId, DateTime newLastMaintenancePart, CancellationToken cancellationToken);

    /// <summary>
    /// GetConditionPartsByVehicleIdAsync
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<ConditionPart>> GetConditionPartsByVehicleIdAsync(Guid? vehicleId, CancellationToken cancellationToken);

    /// <summary>
    /// GetConditionPartByPartIdAsync
    /// </summary>
    /// <param name="partId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ConditionPart> GetConditionPartByPartIdAsync(Guid partId, CancellationToken cancellationToken);
}