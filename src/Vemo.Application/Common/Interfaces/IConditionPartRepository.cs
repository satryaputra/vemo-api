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
    /// GetConditionPartsByVehicleIdAsync
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<ConditionPart>> GetConditionPartsByVehicleIdAsync(Guid vehicleId, CancellationToken cancellationToken);
}