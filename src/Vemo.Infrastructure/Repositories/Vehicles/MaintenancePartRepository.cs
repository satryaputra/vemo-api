using Microsoft.EntityFrameworkCore;
using Vemo.Application.Common.Exceptions;
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

    /// <summary>
    /// UpdateMaintenancePriceAsync
    /// </summary>
    /// <param name="maintenancePart"></param>
    /// <param name="newPrice"></param>
    /// <param name="cancellationToken"></param>
    public async Task UpdateMaintenancePriceAsync(MaintenancePart maintenancePart, double newPrice,
        CancellationToken cancellationToken)
    {
        maintenancePart.MaintenanceFinalPrice = newPrice;
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// GetMaintenancePartById
    /// </summary>
    /// <param name="maintenancePartId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<MaintenancePart> GetMaintenancePartById(Guid maintenancePartId,
        CancellationToken cancellationToken)
    {
        return await _context.MaintenanceParts.FindAsync(new object?[] { maintenancePartId }, cancellationToken)
               ?? throw new NotFoundException("Maintenance Part tidak ditemukan");
    }

    /// <summary>
    /// GetMaintenancePartByIdAsync
    /// </summary>
    /// <param name="maintenanceVehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<MaintenancePart>> GetMaintenancePartsByMaintenanceVehicleIdAsync(Guid maintenanceVehicleId,
        CancellationToken cancellationToken)
    {
        return await _context.MaintenanceParts.Where(x => x.MaintenanceVehicleId.Equals(maintenanceVehicleId))
            .ToListAsync(cancellationToken);
    }
}