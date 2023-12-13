using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Common.Interfaces;

/// <summary>
/// IVehiclePartRepository
/// </summary>
public interface IVehiclePartRepository
{
    /// <summary>
    /// AddVehiclePartAsync
    /// </summary>
    /// <param name="vehiclePart"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddVehiclePartAsync(VehiclePart vehiclePart, CancellationToken cancellationToken);

    /// <summary>
    /// GetVehiclePartByIdAsync
    /// </summary>
    /// <param name="vehiclePartId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<VehiclePart> GetVehiclePartByIdAsync(Guid vehiclePartId, CancellationToken cancellationToken);

    /// <summary>
    /// GetVehiclePartsByVehicleType
    /// </summary>
    /// <param name="vehicleType"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<VehiclePart>> GetVehiclePartsByVehicleType(string vehicleType, CancellationToken cancellationToken);
}