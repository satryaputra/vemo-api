using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Common.Interfaces;

/// <summary>
/// IVehiclePartConditionRepository
/// </summary>
public interface IVehiclePartConditionRepository
{
    /// <summary>
    /// AddVehiclePartConditionAsync
    /// </summary>
    /// <param name="vehiclePartCondition"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddVehiclePartConditionAsync(VehiclePartCondition vehiclePartCondition, CancellationToken cancellationToken);

    /// <summary>
    /// GetVehiclePartConditionByUserIdAsync
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<VehiclePartCondition>> GetVehiclesPartConditionByVehicleIdAsync(Guid vehicleId, CancellationToken cancellationToken);
}