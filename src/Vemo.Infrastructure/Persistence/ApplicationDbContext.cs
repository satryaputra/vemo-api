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
    public DbSet<VehiclePartCondition> VehiclePartConditions { get; set; } = null!;

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

        modelBuilder.Entity<VehiclePart>()
            .HasData(
                new VehiclePart
                {
                    Id = Guid.NewGuid(),
                    Name = "Oli",
                    AgeInMonth = 4,
                    MaintenancePrice = 50000,
                    MaintenanceServicePrice = 10000,
                    VehicleType = null,
                    CreatedAt = DateTime.UtcNow
                },
                new VehiclePart
                {
                    Id = Guid.NewGuid(),
                    Name = "Radiator",
                    AgeInMonth = 10,
                    MaintenancePrice = 30000,
                    MaintenanceServicePrice = 20000,
                    VehicleType = null,
                    CreatedAt = DateTime.UtcNow
                },
                new VehiclePart
                {
                    Id = Guid.NewGuid(),
                    Name = "Busi",
                    AgeInMonth = 6,
                    MaintenancePrice = 25000,
                    MaintenanceServicePrice = 5000,
                    VehicleType = null,
                    CreatedAt = DateTime.UtcNow
                },
                new VehiclePart
                {
                    Id = Guid.NewGuid(),
                    Name = "Rem",
                    AgeInMonth = 5,
                    MaintenancePrice = 40000,
                    MaintenanceServicePrice = 15000,
                    VehicleType = null,
                    CreatedAt = DateTime.UtcNow
                },
                new VehiclePart
                {
                    Id = Guid.NewGuid(),
                    Name = "Ban",
                    AgeInMonth = 24,
                    MaintenancePrice = 300000,
                    MaintenanceServicePrice = 25000,
                    VehicleType = null,
                    CreatedAt = DateTime.UtcNow
                },
                new VehiclePart
                {
                    Id = Guid.NewGuid(),
                    Name = "Aki",
                    AgeInMonth = 3,
                    MaintenancePrice = 20000,
                    MaintenanceServicePrice = 10000,
                    VehicleType = null,
                    CreatedAt = DateTime.UtcNow
                },
                new VehiclePart
                {
                    Id = Guid.NewGuid(),
                    Name = "V-Belt",
                    AgeInMonth = 8,
                    MaintenancePrice = 60000,
                    MaintenanceServicePrice = 20000,
                    VehicleType = "matic",
                    CreatedAt = DateTime.UtcNow
                },
                new VehiclePart
                {
                    Id = Guid.NewGuid(),
                    Name = "CVT",
                    AgeInMonth = 12,
                    MaintenancePrice = 100000,
                    MaintenanceServicePrice = 20000,
                    VehicleType = "matic",
                    CreatedAt = DateTime.UtcNow
                },
                new VehiclePart
                {
                    Id = Guid.NewGuid(),
                    Name = "Rantai dan Gear",
                    AgeInMonth = 8,
                    MaintenancePrice = 100000,
                    MaintenanceServicePrice = 20000,
                    VehicleType = "manual",
                    CreatedAt = DateTime.UtcNow
                },
                new VehiclePart
                {
                    Id = Guid.NewGuid(),
                    Name = "Kampas Kopling",
                    AgeInMonth = 9,
                    MaintenancePrice = 100000,
                    MaintenanceServicePrice = 20000,
                    VehicleType = "manual",
                    CreatedAt = DateTime.UtcNow
                }
            );

        base.OnModelCreating(modelBuilder);
    }
}