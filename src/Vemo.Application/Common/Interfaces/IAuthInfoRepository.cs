using Vemo.Domain.Entities.Users;

namespace Vemo.Application.Common.Interfaces;

/// <summary>
/// IAuthInfoRepository
/// </summary>
public interface IAuthInfoRepository
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
    /// DeleteRefreshTokenAsync
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteRefreshTokenAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// AddNewOtpAsync
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="otp"></param>
    /// <param name="otpExpires"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddNewOtpAsync(Guid userId, int otp, DateTime otpExpires, CancellationToken cancellationToken);

    /// <summary>
    /// GetUserAuthInfoByUserIdAsync
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<AuthInfo> GetAuthInfoByUserIdAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// IsUserAuthInfoExistsByUserIdAsync
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> IsAuthInfoExistsByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}