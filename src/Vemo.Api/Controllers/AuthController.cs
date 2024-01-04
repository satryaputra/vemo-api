using Vemo.Application.Features.Auth.Commands.Login;
using Vemo.Application.Features.Auth.Commands.Logout;
using Vemo.Application.Features.Auth.Commands.RefreshToken;
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
    public async Task<IActionResult> LoginUser(
        LoginCommand loginCommand,
        CancellationToken cancellationToken)
    {
        var refreshAccessTokenResponse = await Mediator.Send(loginCommand, cancellationToken);
        SetRefreshToken(refreshAccessTokenResponse.RefreshToken, refreshAccessTokenResponse.RefreshTokenExpires);
        return Ok(new { refreshAccessTokenResponse.AccessToken });
    }

    /// <summary>
    /// RefreshToken
    /// </summary>
    /// <param name="accessToken"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ForbiddenException"></exception>
    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshAccessToken(
        [FromQuery] string accessToken,
        CancellationToken cancellationToken)
    {
        var refreshToken = Request.Cookies[RefreshTokenHandler.GetKey] ??
                           throw new ForbiddenException("invalid_refresh_token");

        var refreshAccessTokenResponse = await Mediator.Send(new RefreshTokenCommand
        {
            AccessToken = accessToken,
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
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("password/reset")]
    public async Task<IActionResult> ResetPasswordRequest(
        [FromQuery] string email,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new ResetPasswordRequestQuery { Email = email }, cancellationToken));
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
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("otp"), Authorize]
    public async Task<IActionResult> SendOtp([FromQuery] string email, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new SendOtpCommand
            {
                AccessToken = GetAccessTokenFromHeader(),
                Email = email
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

    /// <summary>
    /// Logout
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("logout")]
    public async Task<IActionResult> Logout(CancellationToken cancellationToken)
    {
        Response.Cookies.Delete(RefreshTokenHandler.GetKey);
        await Mediator.Send(new LogoutCommand { AccessToken = GetAccessTokenFromHeader() }, cancellationToken);
        return NoContent();
    }
}