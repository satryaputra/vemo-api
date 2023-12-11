using Vemo.Domain.Entities.Users;

namespace Vemo.Application.Common.Interfaces;

/// <summary>
/// IUserRepository
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// CreateUserAsync
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CreateUserAsync(User user, CancellationToken cancellationToken);

    /// <summary>
    /// GetUserIdByIdAsync
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<User> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// GetUserByEmailAsync
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken);

    /// <summary>
    /// UpdateUserAsync
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="name"></param>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateUserAsync(Guid userId, string name, string email, CancellationToken cancellationToken);

    /// <summary>
    /// UpdatePasswordAsync
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="newPassword"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdatePasswordAsync(Guid userId, string newPassword, CancellationToken cancellationToken);

    /// <summary>
    /// IsUserExistsByEmailAsync
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> IsUserExistsByEmailAsync(string email, CancellationToken cancellationToken);
}