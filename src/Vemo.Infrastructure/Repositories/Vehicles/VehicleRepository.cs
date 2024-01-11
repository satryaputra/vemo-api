using Microsoft.EntityFrameworkCore;
using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Infrastructure.Repositories.Vehicles;

/// <summary>
/// VehicleRepository
/// </summary>
public class VehicleRepository : IVehicleRepository
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Initialize a new intance of the <see cref="VehicleRepository"/> class.
    /// </summary>
    /// <param name="context"></param>
    public VehicleRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// AddVehicleAsync
    /// </summary>
    /// <param name="vehicle"></param>
    /// <param name="cancellationToken"></param>
    public async Task AddVehicleAsync(Vehicle vehicle, CancellationToken cancellationToken)
    {
        await _context.Vehicles.AddAsync(vehicle, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// UpdateStatusVehicleAsync
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="status"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task UpdateStatusVehicleAsync(Guid vehicleId, string status, CancellationToken cancellationToken)
    {
        var vehicle = await GetVehicleByIdAsync(vehicleId, cancellationToken);
        vehicle.Status = status;
        vehicle.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// UpdateMaintenaceStatusVehicleAsync
    /// </summary>
    /// <param name="vehicle"></param>
    /// <param name="status"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="NotImplementedException"></exception>
    public async Task UpdateMaintenaceStatusVehicleAsync(Vehicle vehicle, string status,
        CancellationToken cancellationToken)
    {
        vehicle.MaintenanceStatus = status;
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// ApproveVehicleAsync
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="NotImplementedException"></exception>
    public async Task ApproveVehicleAsync(Guid vehicleId, CancellationToken cancellationToken)
    {
        var vehicle = await GetVehicleByIdAsync(vehicleId, cancellationToken);
        if (vehicle.Status.Equals(Approve()))
        {
            throw new BadRequestException("Kendaraan sudah disetujui");
        }
        else
        {
            vehicle.Status = Approve();
            vehicle.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    /// <summary>
    /// GetVehicleByIdAsync
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Vehicle> GetVehicleByIdAsync(Guid vehicleId, CancellationToken cancellationToken)
    {
        return await _context.Vehicles.FindAsync(new object?[] { vehicleId }, cancellationToken)
               ?? throw new NotFoundException("Kendaraan tidak ditemukan | GetVehicleByIdAsync");
    }

    /// <summary>
    /// GetAllVehiclesAsync
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<Vehicle>> GetAllVehiclesAsync(CancellationToken cancellationToken)
    {
        return await _context.Vehicles.ToListAsync(cancellationToken);
    }

    /// <summary>
    /// GetVehiclesByStatusAsync
    /// </summary>
    /// <param name="status"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<Vehicle>> GetVehiclesByStatusAsync(string? status, CancellationToken cancellationToken)
    {
        return await _context.Vehicles.Where(v => v.Status.Equals(status)).ToListAsync(cancellationToken);
    }

    /// <summary>
    /// GetVehiclesByMaintenanceStatusAsync
    /// </summary>
    /// <param name="maintenanceStatus"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<Vehicle>> GetVehiclesByMaintenanceStatusAsync(string? maintenanceStatus,
        CancellationToken cancellationToken)
    {
        return await _context.Vehicles
            .Where(v => v.MaintenanceStatus != null && v.MaintenanceStatus.Equals(maintenanceStatus))
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// GetVehicleByUserIdAsync
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<Vehicle>> GetVehiclesByUserIdAsync(Guid? userId, CancellationToken cancellationToken)
    {
        return await _context.Vehicles.Where(v => v.UserId.Equals(userId)).ToListAsync(cancellationToken);
    }

    /// <summary>
    /// IsVehicleExistsByLicensePlateAsync
    /// </summary>
    /// <param name="licensePlate"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> IsVehicleExistsByLicensePlateAsync(string licensePlate, CancellationToken cancellationToken)
    {
        return await _context.Vehicles.AnyAsync(v => v.LicensePlate.Equals(licensePlate), cancellationToken);
    }

    /// <summary>
    /// Pending
    /// </summary>
    /// <returns></returns>
    public string Pending()
    {
        return "pending";
    }

    /// <summary>
    /// Approve
    /// </summary>
    /// <returns></returns>
    public string Approve()
    {
        return "approved";
    }
}