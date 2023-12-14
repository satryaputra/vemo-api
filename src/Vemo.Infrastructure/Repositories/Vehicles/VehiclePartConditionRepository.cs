using Microsoft.EntityFrameworkCore;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Infrastructure.Repositories.Vehicles;

/// <summary>
/// VehiclePartConditionRepository
/// </summary>
public class VehiclePartConditionRepository : IVehiclePartConditionRepository
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Initialize a new instance of the <see cref="VehiclePartConditionRepository"/> class.
    /// </summary>
    /// <param name="context"></param>
    public VehiclePartConditionRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// AddVehiclePartConditionAsync
    /// </summary>
    /// <param name="vehiclePartCondition"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task AddVehiclePartConditionAsync(VehiclePartCondition vehiclePartCondition, CancellationToken cancellationToken)
    {
        await _context.VehiclePartConditions.AddAsync(vehiclePartCondition, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// GetVehiclePartConditionByUserIdAsync
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<VehiclePartCondition>> GetVehiclesPartConditionByVehicleIdAsync(Guid vehicleId, CancellationToken cancellationToken)
    {
        return await _context.VehiclePartConditions
            .Where(x => x.VehicleId.Equals(vehicleId))
            .ToListAsync(cancellationToken);
    }
}