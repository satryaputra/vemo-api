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
    /// RequestMaintenance
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public string RequestMaintenance()
    {
        return "requested";
    }
}