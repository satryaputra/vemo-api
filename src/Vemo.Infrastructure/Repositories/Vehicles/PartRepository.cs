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
    /// AddPartAsync
    /// </summary>
    /// <param name="part"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="NotImplementedException"></exception>
    public async Task AddPartAsync(Part part, CancellationToken cancellationToken)
    {
        await _context.Parts.AddAsync(part, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// UpdatePartAsync
    /// </summary>
    /// <param name="part"></param>
    /// <param name="cancellationToken"></param>
    public async Task UpdatePartAsync(Part part, CancellationToken cancellationToken)
    {
        _context.Parts.Update(part);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// DeletePartAsync
    /// </summary>
    /// <param name="part"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task DeletePartAsync(Part part, CancellationToken cancellationToken)
    {
        _context.Parts.Remove(part);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// GetAllPartsAsync
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<Part>> GetAllPartsAsync(CancellationToken cancellationToken)
    {
        return await _context.Parts.ToListAsync(cancellationToken);
    }

    /// <summary>
    /// GetPartByIdAsync
    /// </summary>
    /// <param name="partId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Part> GetPartByIdAsync(Guid partId, CancellationToken cancellationToken)
    {
        return await _context.Parts.FindAsync(new object?[] { partId }, cancellationToken)
               ?? throw new NotFoundException("Komponen kendaraan tidak ditemukan | GetPartIdAsync");
    }

    /// <summary>
    /// GetPartsByVehicleType
    /// </summary>
    /// <param name="vehicleType"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<Part>> GetPartsByVehicleType(string vehicleType, CancellationToken cancellationToken)
    {
        return await _context.Parts
            .Where(p => p.VehicleType == null || p.VehicleType.Equals(vehicleType))
            .ToListAsync(cancellationToken);
    }
}