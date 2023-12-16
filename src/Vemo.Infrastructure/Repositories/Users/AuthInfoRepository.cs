using Microsoft.EntityFrameworkCore;
using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Users;

namespace Vemo.Infrastructure.Repositories.Users;

/// <summary>
/// AuthInfoRepository
/// </summary>
public class AuthInfoRepository : IAuthInfoRepository
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Initialize a new instance of the <see cref="AuthInfoRepository"/> class.
    /// </summary>
    /// <param name="context"></param>
    public AuthInfoRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// AddRefreshTokenAsync
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="refreshToken"></param>
    /// <param name="refreshTokenExpires"></param>
    /// <param name="cancellationToken"></param>
    public async Task AddNewRefreshTokenAsync(Guid userId, string refreshToken, DateTime refreshTokenExpires, CancellationToken cancellationToken)
    {
        if (await IsAuthInfoExistsByUserIdAsync(userId, cancellationToken))
        {
            var userAuthInfo = await GetAuthInfoByUserIdAsync(userId, cancellationToken);
            userAuthInfo.RefreshToken = refreshToken;
            userAuthInfo.RefreshTokenExpires = refreshTokenExpires;
            await _context.SaveChangesAsync(cancellationToken);
        }
        else
        {
            var newUserAuthInfo = new AuthInfo
            {
                RefreshToken = refreshToken,
                RefreshTokenExpires = refreshTokenExpires,
                UserId = userId
            };
            await _context.AuthInfos.AddAsync(newUserAuthInfo, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    /// <summary>
    /// AddNewOtpAsync
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="otp"></param>
    /// <param name="otpExpires"></param>
    /// <param name="cancellationToken"></param>
    public async Task AddNewOtpAsync(Guid userId, int otp, DateTime otpExpires, CancellationToken cancellationToken)
    {
        var userAuthInfo = await GetAuthInfoByUserIdAsync(userId, cancellationToken);
        userAuthInfo.Otp = otp;
        userAuthInfo.OtpExpires = otpExpires;
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// GetUserAuthInfoByUserId
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<AuthInfo> GetAuthInfoByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _context.AuthInfos.FirstOrDefaultAsync(x => x.UserId.Equals(userId), cancellationToken)
               ?? throw new NotFoundException("AuthInfo tidak ditemukan | GetUserAuthInfoByUserId");
    }

    /// <summary>
    /// IsUserAuthInfoExistsByUserIdAsync
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<bool> IsAuthInfoExistsByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return _context.AuthInfos.AnyAsync(x => x.UserId.Equals(userId), cancellationToken);
    }
}