﻿using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Application.Common.Utils;

namespace Vemo.Application.Features.Auth.Commands.Login;

/// <summary>
/// LoginCommandHandler
/// </summary>
internal sealed class LoginCommandHandler :IRequestHandler<LoginCommand, TokenResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthInfoRepository _authInfoRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="LoginCommandHandler"/> class.
    /// </summary>
    /// <param name="userRepository"></param>
    /// <param name="authInfoRepository"></param>
    public LoginCommandHandler(
        IUserRepository userRepository, 
        IAuthInfoRepository authInfoRepository)
    {
        _userRepository = userRepository;
        _authInfoRepository = authInfoRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="BadRequestException"></exception>
    public async Task<TokenResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        if (!await _userRepository.IsUserExistsByEmailAsync(request.Email, cancellationToken))
        {
            throw new BadRequestException("Email belum terdaftar");
        }

        var user = await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken);

        if (!PasswordHasher.VerifyPassword(request.Password, user.Password))
        {
            throw new BadRequestException("Password salah");
        }
        
        var accessToken = TokenBuilder.CreateAccessToken(user.Id, user.Role);
        var refreshToken = TokenBuilder.CreateRefreshToken();
        var refreshTokenExpires = TokenBuilder.GetRefreshTokenExpired();
        
        await _authInfoRepository.AddNewRefreshTokenAsync(user.Id, refreshToken, refreshTokenExpires, cancellationToken);

        return new TokenResponseDto(accessToken, refreshToken, refreshTokenExpires);
    }
}