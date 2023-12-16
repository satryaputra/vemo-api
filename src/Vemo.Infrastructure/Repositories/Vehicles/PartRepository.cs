using Microsoft.EntityFrameworkCore;
using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Infrastructure.Repositories.Vehicles;

/// <summary>
/// PartRepository
/// </summary>
public class PartRepository : IPartRepository
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Initialize a new instance of the <see cref="PartRepository"/> class.
    /// </summary>
    /// <param name="context"></param>
    public PartRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// AddPartVehicleAsync
    /// </summary>
    /// <param name="part"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="NotImplementedException"></exception>
    public async Task AddPartVehicleAsync(Part part, CancellationToken cancellationToken)
    {
        await _context.PartVehicles.AddAsync(part, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// GetPartVehicleByIdAsync
    /// </summary>
    /// <param name="vehiclePartId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Part> GetPartVehicleByIdAsync(Guid vehiclePartId, CancellationToken cancellationToken)
    {
        return await _context.PartVehicles.FindAsync(new object?[] { vehiclePartId }, cancellationToken)
               ?? throw new NotFoundException("Komponen kendaraan tidak ditemukan | GetPartVehicleByIdAsync");
    }

    /// <summary>
    /// GetPartVehiclesByVehicleType
    /// </summary>
    /// <param name="vehicleType"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<Part>> GetPartVehiclesByVehicleType(string vehicleType, CancellationToken cancellationToken)
    {
        return await _context.PartVehicles
            .Where(p => p.VehicleType == null || p.VehicleType.Equals(vehicleType))
            .ToListAsync(cancellationToken);
    }
}