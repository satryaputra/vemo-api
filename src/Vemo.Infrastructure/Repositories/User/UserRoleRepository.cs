using Microsoft.EntityFrameworkCore;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.User;

namespace Vemo.Infrastructure.Repositories.User;

/// <summary>
/// UserRoleRepository
/// </summary>
public class UserRoleRepository : IUserRoleRepository
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Initialize a new instance of the <see cref="UserRoleRepository"/> class.
    /// </summary>
    /// <param name="context">Set context to perform CRUD into Database</param>
    public UserRoleRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// CreateUserRole
    /// </summary>
    /// <param name="role"></param>
    /// <param name="cancellationToken"></param>
    public async Task<UserRole> CreateUserRoleAsync(string role, CancellationToken cancellationToken)
    {
        var newRole = new UserRole
        {
            Id = Guid.NewGuid(),
            Role = role
        };

        await _context.UserRoles.AddAsync(newRole, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return newRole;
    }

    /// <summary>
    /// GetRolesAsync
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<UserRole>> GetUserRolesAsync(CancellationToken cancellationToken)
    {
        return await _context.UserRoles.ToListAsync(cancellationToken);
    }

    /// <summary>
    /// GetUserRoleByIdAsync
    /// </summary>
    /// <param name="userRoleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<UserRole> GetUserRoleByIdAsync(Guid userRoleId, CancellationToken cancellationToken)
    {
        return await _context.UserRoles.FindAsync(new object?[] {userRoleId}, cancellationToken)
            ?? throw new Exception("UserRole tidak ditemukan");
    }

    /// <summary>
    /// DeleteRoleAsync
    /// </summary>
    /// <param name="userRoleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task DeleteRoleAsync(Guid userRoleId, CancellationToken cancellationToken)
    {
        var role = await GetUserRoleByIdAsync(userRoleId, cancellationToken);
        _context.UserRoles.Remove(role);
        await _context.SaveChangesAsync(cancellationToken);
    }
}