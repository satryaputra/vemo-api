using Microsoft.EntityFrameworkCore;
using Vemo.Domain.Entities.Notifications;
using Vemo.Domain.Entities.Users;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Common.Interfaces;

/// <summary>
/// IApplicationDbContext
/// </summary>
public interface IApplicationDbContext
{
    /// <summary>
    /// Gets or sets Users
    /// </summary>
    public DbSet<User> Users { get; set; }
    
    /// <summary>
    /// Gets or sets UserAuthInfos
    /// </summary>
    public DbSet<UserAuthInfo> UserAuthInfos { get; set; }
    
    /// <summary>
    /// Gets or sets Vehicles
    /// </summary>
    public DbSet<Vehicle> Vehicles { get; set; }
    
    /// <summary>
    /// Gets or sets Vehicles
    /// </summary>
    public DbSet<VehiclePart> VehicleParts { get; set; }
    
    /// <summary>
    /// Gets or sets Vehicles
    /// </summary>
    public DbSet<VehiclePartMaintenance> VehiclePartMaintenances { get; set; }
    
    /// <summary>
    /// Gets or sets Vehicles
    /// </summary>
    public DbSet<Notification> Notifications { get; set; }
    
    /// <summary>
    /// SaveChangesAsync
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}