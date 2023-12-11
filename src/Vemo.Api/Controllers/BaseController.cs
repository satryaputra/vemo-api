using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vemo.Api.Common.Utils;
using Vemo.Application.Common.Exceptions;

namespace Vemo.Api.Controllers;

/// <summary>
/// Base class for object controllers.
/// </summary>
[ApiController]
public class BaseController : ControllerBase
{
    private IMediator? _mediator;

    /// <summary>
    /// Gets protected variable to encapsulate request/response and publishing interaction patterns.
    /// </summary>
    /// <returns></returns>
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

    /// <summary>
    /// SetRefreshToken
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <param name="refreshTokenExpires"></param>
    protected void SetRefreshToken(string refreshToken, DateTime refreshTokenExpires)
    {
        Response.Cookies.Append(
            RefreshTokenHandler.GetKey, 
            refreshToken,
            CookieSettings.AddExpires(refreshTokenExpires));
    }

    /// <summary>
    /// GetAccessTokenFromHeader
    /// </summary>
    /// <returns></returns>
    /// <exception cref="UnauthorizedException"></exception>
    protected string GetAccessTokenFromHeader()
    {
        if (!Request.Headers.TryGetValue("Authorization", out var bearerToken))
            throw new UnauthorizedException("invalid_access_token");

        var bearerTokenString = bearerToken.ToString() ?? throw new UnauthorizedException("invalid_access_token");

        return  bearerTokenString.Split(" ").Last();
    }
}