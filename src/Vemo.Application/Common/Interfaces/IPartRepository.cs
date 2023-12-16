using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Common.Interfaces;

/// <summary>
/// IPartRepository
/// </summary>
public interface IPartRepository
{
    /// <summary>
    /// AddPartVehicleAsync
    /// </summary>
    /// <param name="part"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddPartVehicleAsync(Part part, CancellationToken cancellationToken);

    /// <summary>
    /// GetPartVehicleByIdAsync
    /// </summary>
    /// <param name="vehiclePartId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Part> GetPartVehicleByIdAsync(Guid vehiclePartId, CancellationToken cancellationToken);

    /// <summary>
    /// GetPartVehiclesByVehicleType
    /// </summary>
    /// <param name="vehicleType"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<Part>> GetPartVehiclesByVehicleType(string vehicleType, CancellationToken cancellationToken);
}