using Vemo.Domain.Entities.Users;

namespace Vemo.Application.Common.Interfaces;

/// <summary>
/// IUserAuthInfoRepository
/// </summary>
public interface IUserAuthInfoRepository
{
    /// <summary>
    /// AddRefreshTokenAsync
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="refreshToken"></param>
    /// <param name="refreshTokenExpires"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddNewRefreshTokenAsync(Guid userId, string refreshToken, DateTime refreshTokenExpires, CancellationToken cancellationToken);

    /// <summary>
    /// GetUserAuthInfoByUserId
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserAuthInfo> GetUserAuthInfoByUserId(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// IsUserAuthInfoExistsByUserIdAsync
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> IsUserAuthInfoExistsByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}