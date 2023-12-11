using Microsoft.AspNetCore.Mvc;
using Vemo.Api.Common.Utils;
using Vemo.Application.Features.Users.Commands.CreateUser;

namespace Vemo.Api.Controllers;

/// <summary>
/// Represents RESTful of User
/// </summary>
[Route("auth")]
public class AuthController : BaseController
{
    /// <summary>
    /// RegisterUser
    /// </summary>
    /// <param name="createUserCommand"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(
        CreateUserCommand createUserCommand,
        CancellationToken cancellationToken)
    {
        var registerUserResponse = await Mediator.Send(createUserCommand, cancellationToken);
        SetRefreshToken(registerUserResponse.RefreshToken, registerUserResponse.RefreshTokenExpires);
        return Ok(new { registerUserResponse.AccessToken });
    }
}