using Microsoft.EntityFrameworkCore;
using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Infrastructure.Repositories.Vehicles;

/// <summary>
/// MaintenanceVehicleRepository
/// </summary>
public class MaintenanceVehicleRepository : IMaintenanceVehicleRepository
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Initialize a new instance of the <see cref="MaintenanceVehicleRepository"/> class.
    /// </summary>
    /// <param name="context"></param>
    public MaintenanceVehicleRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// AddMaintenanceVehicleAsync
    /// </summary>
    /// <param name="newMaintenanceVehicle"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="NotImplementedException"></exception>
    public async Task AddMaintenanceVehicleAsync(
        MaintenanceVehicle newMaintenanceVehicle,
        CancellationToken cancellationToken)
    {
        await _context.MaintenanceVehicles.AddAsync(newMaintenanceVehicle, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// UpdateStatusAsync
    /// </summary>
    /// <param name="maintenanceVehicle"></param>
    /// <param name="status"></param>
    /// <param name="cancellationToken"></param>
    public async Task UpdateStatusAsync(MaintenanceVehicle maintenanceVehicle, string status,
        CancellationToken cancellationToken)
    {
        maintenanceVehicle.Status = status;
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// GetMaintenanceVehicleByIdAsync
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<MaintenanceVehicle> GetMaintenanceVehicleByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.MaintenanceVehicles.FindAsync(new object?[] { id }, cancellationToken) ??
               throw new NotFoundException("Maintenance Vehicle tidak ditemukan");
    }

    /// <summary>
    /// GetMaintenanceVehicleById
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<MaintenanceVehicle>> GetMaintenanceVehicleByVehicleIdAsync(Guid vehicleId,
        CancellationToken cancellationToken)
    {
        return await _context.MaintenanceVehicles
            .Where(x => x.VehicleId.Equals(vehicleId)).ToListAsync(cancellationToken);
    }

    /// <summary>
    /// GetRequestByVehicleId
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<MaintenanceVehicle?> GetRequestByVehicleIdAsync(Guid vehicleId,
        CancellationToken cancellationToken)
    {
        return await _context.MaintenanceVehicles
            .FirstOrDefaultAsync(x => x.Status.Equals("requested") && x.VehicleId.Equals(vehicleId), cancellationToken);
    }

    /// <summary>
    /// RequestMaintenance
    /// </summary>
    /// <returns></returns>
    public string RequestMaintenance()
    {
        return "requested";
    }

    public string ServiceMaintenance()
    {
        return "service";
    }
}