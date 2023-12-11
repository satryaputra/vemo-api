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
    /// IsUserExistsByEmailAsync
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> IsUserExistsByEmailAsync(string email, CancellationToken cancellationToken);
}