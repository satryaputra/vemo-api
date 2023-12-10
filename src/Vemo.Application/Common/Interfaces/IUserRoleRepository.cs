using Vemo.Domain.Entities.User;

namespace Vemo.Application.Common.Interfaces;

/// <summary>
/// IUserRoleRepository
/// </summary>
public interface IUserRoleRepository
{
    /// <summary>
    /// CreateUserRoleAsync
    /// </summary>
    /// <param name="role"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserRole> CreateUserRoleAsync(string role, CancellationToken cancellationToken);

    /// <summary>
    /// GetRolesAsync
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<UserRole>> GetUserRolesAsync(CancellationToken cancellationToken);

    /// <summary>
    /// GetUserRoleByIdAsync
    /// </summary>
    /// <param name="userRoleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserRole> GetUserRoleByIdAsync(Guid userRoleId, CancellationToken cancellationToken);

    /// <summary>
    /// DeleteRoleAsync
    /// </summary>
    /// <param name="userRoleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteRoleAsync(Guid userRoleId, CancellationToken cancellationToken);
}