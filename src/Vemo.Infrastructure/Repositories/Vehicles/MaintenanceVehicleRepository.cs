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
    /// GetMaintenanceVehicleById
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<MaintenanceVehicle?> GetMaintenanceVehicleByVehicleIdAsync(Guid vehicleId,
        CancellationToken cancellationToken)
    {
        return await _context.MaintenanceVehicles
            .SingleOrDefaultAsync(x => x.VehicleId.Equals(vehicleId), cancellationToken);
    }

    /// <summary>
    /// RequestMaintenance
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public string RequestMaintenance()
    {
        return "requested";
    }
}