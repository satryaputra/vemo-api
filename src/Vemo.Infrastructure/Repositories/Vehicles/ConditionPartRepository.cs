using Microsoft.EntityFrameworkCore;
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
        await _context.ConditionPartVehicles.AddAsync(conditionPart, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// GetConditionPartsByVehicleIdAsync
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<ConditionPart>> GetConditionPartsByVehicleIdAsync(Guid vehicleId, CancellationToken cancellationToken)
    {
        return await _context.ConditionPartVehicles
            .Where(x => x.VehicleId.Equals(vehicleId))
            .ToListAsync(cancellationToken);
    }
}