using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Infrastructure.Repositories.Vehicles;

public class MaintenancePartRepository : IMaintenancePartRepository
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Initialize a new instance of the <see cref="MaintenanceVehicleRepository"/> class.
    /// </summary>
    /// <param name="context"></param>
    public MaintenancePartRepository(IApplicationDbContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// AddMaintenancePartAsync
    /// </summary>
    /// <param name="newMaintenancePart"></param>
    /// <param name="cancellationToken"></param>
    public async Task AddMaintenancePartAsync(MaintenancePart newMaintenancePart, CancellationToken cancellationToken)
    {
        await _context.MaintenanceParts.AddAsync(newMaintenancePart, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}