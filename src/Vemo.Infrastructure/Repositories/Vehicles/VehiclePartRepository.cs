using Microsoft.EntityFrameworkCore;
using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Infrastructure.Repositories.Vehicles;

/// <summary>
/// VehiclePartRepository
/// </summary>
public class VehiclePartRepository : IVehiclePartRepository
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Initialize a new instance of the <see cref="VehiclePartRepository"/> class.
    /// </summary>
    /// <param name="context"></param>
    public VehiclePartRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// AddVehiclePartAsync
    /// </summary>
    /// <param name="vehiclePart"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="NotImplementedException"></exception>
    public async Task AddVehiclePartAsync(VehiclePart vehiclePart, CancellationToken cancellationToken)
    {
        await _context.VehicleParts.AddAsync(vehiclePart, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// GetVehiclePartByIdAsync
    /// </summary>
    /// <param name="vehiclePartId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<VehiclePart> GetVehiclePartByIdAsync(Guid vehiclePartId, CancellationToken cancellationToken)
    {
        return await _context.VehicleParts.FindAsync(new object?[] { vehiclePartId }, cancellationToken)
               ?? throw new NotFoundException("Komponen kendaraan tidak ditemukan | GetVehiclePartByIdAsync");
    }

    /// <summary>
    /// GetVehiclePartsByVehicleType
    /// </summary>
    /// <param name="vehicleType"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<VehiclePart>> GetVehiclePartsByVehicleType(string vehicleType, CancellationToken cancellationToken)
    {
        return await _context.VehicleParts
            .Where(p => p.VehicleType == null || p.VehicleType.Equals(vehicleType))
            .ToListAsync(cancellationToken);
    }
}