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
    /// IsUserExistsByEmailAsync
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> IsUserExistsByEmailAsync(string email, CancellationToken cancellationToken);
}