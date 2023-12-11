using Microsoft.EntityFrameworkCore;
using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Users;

namespace Vemo.Infrastructure.Repositories.Users;

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
            ?? throw new NotFoundException("UserRole tidak ditemukan | GetUserRoleByIdAsync");
    }

    /// <summary>
    /// GetUserRoleByRole
    /// </summary>
    /// <param name="role"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<UserRole> GetUserRoleByRoleAsync(string role, CancellationToken cancellationToken)
    {
        return await _context.UserRoles.FirstOrDefaultAsync(x => x.Role.Equals(role), cancellationToken)
            ?? throw new NotFoundException("UserRole tidak ditemukan | GetUserRoleByRoleAsync");
    }

    /// <summary>
    /// DeleteRoleAsync
    /// </summary>
    /// <param name="userRoleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task DeleteUserRoleAsync(Guid userRoleId, CancellationToken cancellationToken)
    {
        var role = await GetUserRoleByIdAsync(userRoleId, cancellationToken);
        _context.UserRoles.Remove(role);
        await _context.SaveChangesAsync(cancellationToken);
    }
}