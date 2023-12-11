using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vemo.Api.Common.Utils;
using Vemo.Application.Features.Auth.Commands.Login;
using Vemo.Application.Features.Auth.Commands.SendOtp;
using Vemo.Application.Features.Auth.Queries.VerifyOtp;
using Vemo.Application.Features.Users.Commands.CreateUser;

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
        var loginResponse = await Mediator.Send(loginCommand, cancellationToken);
        SetRefreshToken(loginResponse.RefreshToken, loginResponse.RefreshTokenExpires);
        return Ok(new { loginResponse.AccessToken });
    }

    /// <summary>
    /// SendOtp
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("otp"), Authorize]
    public async Task<IActionResult> SendOtp([FromBody] string email, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new SendOtpCommand { AccessToken = GetAccessTokenFromHeader(), Email = email}, cancellationToken));
    }

    [HttpGet("otp/{otp:int}"), Authorize]
    public async Task<IActionResult> VerifyOtp(int otp, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new VerifyOtpQuery { AccessToken = GetAccessTokenFromHeader(), Otp = otp }, cancellationToken));
    }
}