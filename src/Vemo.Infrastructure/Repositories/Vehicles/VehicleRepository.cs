using Microsoft.EntityFrameworkCore;
using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Infrastructure.Repositories.Vehicles;

/// <summary>
/// VehicleRepository
/// </summary>
public class VehicleRepository : IVehicleRepository
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Initialize a new intance of the <see cref="VehicleRepository"/> class.
    /// </summary>
    /// <param name="context"></param>
    public VehicleRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// AddVehicleAsync
    /// </summary>
    /// <param name="vehicle"></param>
    /// <param name="cancellationToken"></param>
    public async Task AddVehicleAsync(Vehicle vehicle, CancellationToken cancellationToken)
    {
        await _context.Vehicles.AddAsync(vehicle, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// GetVehicleByIdAsync
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Vehicle> GetVehicleByIdAsync(Guid vehicleId, CancellationToken cancellationToken)
    {
        return await _context.Vehicles.FindAsync(new object?[] { vehicleId }, cancellationToken)
            ?? throw new NotFoundException("Kendaraan tidak ditemukan | GetVehicleByIdAsync");
    }

    /// <summary>
    /// IsVehicleExistsByLicensePlateAsync
    /// </summary>
    /// <param name="licensePlate"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> IsVehicleExistsByLicensePlateAsync(string licensePlate, CancellationToken cancellationToken)
    {
        return await _context.Vehicles.AnyAsync(v => v.LicensePlate.Equals(licensePlate), cancellationToken);
    }

    /// <summary>
    /// Pending
    /// </summary>
    /// <returns></returns>
    public string Pending()
    {
        return "pending";
    }

    /// <summary>
    /// Approve
    /// </summary>
    /// <returns></returns>
    public string Approve()
    {
        return "approved";
    }
}