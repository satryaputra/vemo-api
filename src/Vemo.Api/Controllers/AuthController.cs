using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vemo.Api.Common.Utils;
using Vemo.Application.Common.Exceptions;
using Vemo.Application.Dtos;
using Vemo.Application.Features.Auth.Commands.Login;
using Vemo.Application.Features.Auth.Commands.RefreshAccessToken;
using Vemo.Application.Features.Auth.Commands.ResetPassword;
using Vemo.Application.Features.Auth.Commands.SendOtp;
using Vemo.Application.Features.Auth.Queries.ResetPasswordRequest;
using Vemo.Application.Features.Auth.Queries.VerifyOtp;
using Vemo.Application.Features.Auth.Queries.VerifyPassword;

namespace Vemo.Api.Controllers;

/// <summary>
/// Represents RESTful of Auth
/// </summary>
[Route("auth")]
public class AuthController : BaseController
{
    /// <summary>
    /// RegisterUser
    /// </summary>
    /// <param name="loginCommand"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult> RegisterUser(
        LoginCommand loginCommand,
        CancellationToken cancellationToken)
    {
        var refreshAccessTokenResponse = await Mediator.Send(loginCommand, cancellationToken);
        SetRefreshToken(refreshAccessTokenResponse.RefreshToken, refreshAccessTokenResponse.RefreshTokenExpires);
        return Ok(new { refreshAccessTokenResponse.AccessToken });
    }

    /// <summary>
    /// RefreshAccessToken
    /// </summary>
    /// <param name="accessTokenDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ForbiddenException"></exception>
    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshAccessToken(
        [FromBody] AccessTokenDto accessTokenDto,
        CancellationToken cancellationToken)
    {
        var refreshToken = Request.Cookies[RefreshTokenHandler.GetKey] ??
                           throw new ForbiddenException("invalid_refresh_token");

        var refreshAccessTokenResponse = await Mediator.Send(new RefreshAccessTokenCommand
        {
            AccessToken = accessTokenDto.AccessToken,
            RefreshToken = refreshToken
        }, cancellationToken);

        SetRefreshToken(refreshAccessTokenResponse.RefreshToken, refreshAccessTokenResponse.RefreshTokenExpires);
        return Ok(new { refreshAccessTokenResponse.AccessToken });
    }

    /// <summary>
    /// VerifyPassword
    /// </summary>
    /// <param name="verify"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("password"), Authorize]
    public async Task<IActionResult> VerifyPassword(
        [FromQuery] string verify,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new VerifyPasswordQuery
        {
            AccessToken = GetAccessTokenFromHeader(),
            Password = verify
        }, cancellationToken));
    }

    /// <summary>
    /// ResetPasswordRequest
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("password/reset")]
    public async Task<IActionResult> ResetPasswordRequest(
        [FromQuery] string request,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new ResetPasswordRequestQuery { Email = request }, cancellationToken));
    }

    /// <summary>
    /// ResetPassword
    /// </summary>
    /// <param name="resetPasswordCommand"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("password/reset")]
    public async Task<IActionResult> ResetPassword(
        ResetPasswordCommand resetPasswordCommand,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(resetPasswordCommand, cancellationToken));
    }

    /// <summary>
    /// SendOtp
    /// </summary>
    /// <param name="emailDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("otp"), Authorize]
    public async Task<IActionResult> SendOtp([FromBody] EmailDto emailDto, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new SendOtpCommand
            {
                AccessToken = GetAccessTokenFromHeader(), 
                Email = emailDto.Email
            },
            cancellationToken));
    }

    /// <summary>
    /// VerifyOtp
    /// </summary>
    /// <param name="verify"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("otp"), Authorize]
    public async Task<IActionResult> VerifyOtp([FromQuery] int verify, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new VerifyOtpQuery
            {
                AccessToken = GetAccessTokenFromHeader(), 
                Otp = verify
            },
            cancellationToken));
    }
}