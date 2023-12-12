using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Application.Common.Utils;
using Vemo.Domain.Enums;

namespace Vemo.Application.Features.Auth.Commands.RefreshToken;

/// <summary>
/// RefreshTokenCommandHandler
/// </summary>
internal sealed class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, TokenResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserAuthInfoRepository _userAuthInfoRepository;

    /// <summary>
    /// Initialize a new intance of the <see cref="RefreshTokenCommandHandler"/> class.
    /// </summary>
    /// <param name="userRepository"></param>
    /// <param name="userAuthInfoRepository"></param>
    public RefreshTokenCommandHandler(IUserRepository userRepository, IUserAuthInfoRepository userAuthInfoRepository)
    {
        _userRepository = userRepository;
        _userAuthInfoRepository = userAuthInfoRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ForbiddenException"></exception>
    public async Task<TokenResponseDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var userId = TokenBuilder.GetUserIdFromJwtToken(request.AccessToken, TokenType.AccessToken);
        var userAuthInfo = await _userAuthInfoRepository.GetUserAuthInfoByUserIdAsync(userId, cancellationToken);
        
        if (!TokenBuilder.IsValidRefreshToken(userAuthInfo, request.RefreshToken))
        {
            throw new ForbiddenException("invalid_refresh_token");
        }
        
        var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
        
        var accessToken = TokenBuilder.CreateAccessToken(user.Id, user.Role);
        var refreshToken = TokenBuilder.CreateRefreshToken();
        var refreshTokenExpires = TokenBuilder.GetRefreshTokenExpired();
        
        await _userAuthInfoRepository.AddNewRefreshTokenAsync(user.Id, refreshToken, refreshTokenExpires, cancellationToken);

        return new TokenResponseDto(accessToken, refreshToken, refreshTokenExpires);
    }
}