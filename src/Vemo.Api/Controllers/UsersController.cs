﻿using Vemo.Application.Common.Utils;
using Vemo.Application.Features.Users.Commands.CreateUser;
using Vemo.Application.Features.Users.Commands.UpdatePassword;
using Vemo.Application.Features.Users.Commands.UpdateUser;
using Vemo.Application.Features.Users.Queries.GetUserById;
using Vemo.Domain.Enums;

namespace Vemo.Api.Controllers;

/// <summary>
/// Represents RESTful of User
/// </summary>
[Route("users"), Authorize]
public class UsersController : BaseController
{
    /// <summary>
    /// RegisterUser
    /// </summary>
    /// <param name="createUserCommand"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost, AllowAnonymous]
    public async Task<IActionResult> CreateUser(
        CreateUserCommand createUserCommand,
        CancellationToken cancellationToken)
    {
        var createUserResponse = await Mediator.Send(createUserCommand, cancellationToken);
        SetRefreshToken(createUserResponse.RefreshToken, createUserResponse.RefreshTokenExpires);
        return CreatedAtAction(nameof(GetUserById), new { userId = createUserResponse.UserId },
            new { createUserResponse.AccessToken });
    }

    /// <summary>
    /// GetUserById
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{userId:guid}"), Authorize(Roles = "admin")]
    public async Task<IActionResult> GetUserById(
        Guid userId,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetUserByIdQuery { UserId = userId }, cancellationToken));
    }

    /// <summary>
    /// UpdateUser
    /// </summary>
    /// <param name="updateUserCommand"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> UpdateUser(
        UpdateUserCommand updateUserCommand,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(updateUserCommand, cancellationToken));
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetCurrentUser(CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetUserByIdQuery()
            {
                UserId = TokenBuilder.GetUserIdFromJwtToken(GetAccessTokenFromHeader(), TokenType.AccessToken)
            },
            cancellationToken));
    }

    /// <summary>
    /// UpdatePassword
    /// </summary>
    /// <param name="updatePasswordCommand"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch("password")]
    public async Task<IActionResult> UpdatePassword(
        UpdatePasswordCommand updatePasswordCommand,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(updatePasswordCommand, cancellationToken));
    }
}