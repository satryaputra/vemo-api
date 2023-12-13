using Microsoft.EntityFrameworkCore;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Notifications;
using Vemo.Domain.Entities.Users;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Infrastructure.Persistence;

/// <summary>
/// ApplicationDbContext
/// </summary>
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
    /// </summary>
    /// <param name="options"></param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Gets or sets Users
    /// </summary>
    public DbSet<User> Users { get; set; } = null!;

    /// <summary>
    /// Gets or sets UserAuthInfos
    /// </summary>
    public DbSet<UserAuthInfo> UserAuthInfos { get; set; } = null!;

    /// <summary>
    /// Gets or sets Vehicles
    /// </summary>
    public DbSet<Vehicle> Vehicles { get; set; } = null!;

    /// <summary>
    /// Gets or sets VehicleParts
    /// </summary>
    public DbSet<VehiclePart> VehicleParts { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets VehiclePartMaintenanceSchedules
    /// </summary>
    public DbSet<VehiclePartMaintenanceSchedule> VehiclePartMaintenanceSchedules { get; set; } = null!;

    /// <summary>
    /// Gets or sets VehiclePartMaintenanceHistories
    /// </summary>
    public DbSet<VehiclePartMaintenanceHistory> VehiclePartMaintenanceHistories { get; set; } = null!;

    /// <summary>
    /// Gets or sets Notifications
    /// </summary>
    public DbSet<Notification> Notifications { get; set; } = null!;

    /// <summary>
    /// SaveChangesAsync
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
    
    /// <summary>
    /// OnModelCreating
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        
        modelBuilder.Entity<Vehicle>()
            .HasIndex(v => v.LicensePlate)
            .IsUnique();

        base.OnModelCreating(modelBuilder);
    }
}