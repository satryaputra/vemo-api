using Vemo.Domain.Entities.Users;

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
    /// GetUserRoleByRoleAsync
    /// </summary>
    /// <param name="role"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserRole> GetUserRoleByRoleAsync(string role, CancellationToken cancellationToken);

    /// <summary>
    /// DeleteRoleAsync
    /// </summary>
    /// <param name="userRoleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteUserRoleAsync(Guid userRoleId, CancellationToken cancellationToken);

    /// <summary>
    /// IsUserRoleExistsByRole
    /// </summary>
    /// <param name="role"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> IsUserRoleExistsByRole(string role, CancellationToken cancellationToken);
}