using Microsoft.EntityFrameworkCore;
using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Infrastructure.Repositories.Vehicles;

/// <summary>
/// ConditionPartRepository
/// </summary>
public class ConditionPartRepository : IConditionPartRepository
{
    private readonly IApplicationDbContext _context;
    private readonly IPartRepository _partRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="ConditionPartRepository"/> class.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="partRepository"></param>
    public ConditionPartRepository(
        IApplicationDbContext context,
        IPartRepository partRepository)
    {
        _context = context;
        _partRepository = partRepository;
    }

    /// <summary>
    /// AddConditionPartAsync
    /// </summary>
    /// <param name="conditionPart"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task AddConditionPartAsync(ConditionPart conditionPart, CancellationToken cancellationToken)
    {
        await _context.ConditionParts.AddAsync(conditionPart, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// UpdateLastMaintenanceToNowAsync
    /// </summary>
    /// <param name="conditionPart"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task UpdateLastMaintenanceToNowAsync(ConditionPart conditionPart, CancellationToken cancellationToken)
    {
        conditionPart.LastMaintenance = DateTime.UtcNow;
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// GetConditionPartsByVehicleIdAsync
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<ConditionPart>> GetConditionPartsByVehicleIdAsync(Guid? vehicleId,
        CancellationToken cancellationToken)
    {
        return await _context.ConditionParts
            .Where(x => x.VehicleId.Equals(vehicleId))
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// GetConditionPartByPartIdAsync
    /// </summary>
    /// <param name="partId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ConditionPart> GetConditionPartByPartIdAsync(Guid partId, CancellationToken cancellationToken)
    {
        return await _context.ConditionParts.FirstOrDefaultAsync(x => x.PartId.Equals(partId), cancellationToken)
               ?? throw new NotFoundException("Condition Part tidak ditemukan");
    }
}