using Microsoft.EntityFrameworkCore;
using Vemo.Domain.Entities.User;

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
    /// Gets or sets UserRoles
    /// </summary>
    public DbSet<UserRole> UserRoles { get; set; }
    
    /// <summary>
    /// SaveChangesAsync
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}