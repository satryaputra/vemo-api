using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Common.Interfaces;

/// <summary>
/// IVehicleRepository
/// </summary>
public interface IVehicleRepository
{
    /// <summary>
    /// AddVehicleAsync
    /// </summary>
    /// <param name="vehicle"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddVehicleAsync(Vehicle vehicle, CancellationToken cancellationToken);

    /// <summary>
    /// UpdateStatusVehicleAsync
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="status"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateStatusVehicleAsync(Guid vehicleId, string status, CancellationToken cancellationToken);

    /// <summary>
    /// ApproveVehicleAsync
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task ApproveVehicleAsync(Guid vehicleId, CancellationToken cancellationToken);

    /// <summary>
    /// GetVehicleByIdAsync
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Vehicle> GetVehicleByIdAsync(Guid vehicleId, CancellationToken cancellationToken);
    
    /// <summary>
    /// GetAllVehiclesAsync
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<Vehicle>> GetAllVehiclesAsync(CancellationToken cancellationToken);

    /// <summary>
    /// GetVehicleByUserIdAsync
    /// </summary>
    /// <param name="status"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<Vehicle>> GetVehiclesByStatusAsync(string? status, CancellationToken cancellationToken);

    /// <summary>
    /// GetVehicleByUserIdAsync
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<Vehicle>> GetVehiclesByUserIdAsync(Guid? userId, CancellationToken cancellationToken);

    /// <summary>
    /// IsVehicleExistsByLicensePlateAsync
    /// </summary>
    /// <param name="licensePlate"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> IsVehicleExistsByLicensePlateAsync(string licensePlate, CancellationToken cancellationToken);
    
    /// <summary>
    /// Pending
    /// </summary>
    /// <returns></returns>
    string Pending();

    /// <summary>
    /// Approve
    /// </summary>
    /// <returns></returns>
    string Approve();
}