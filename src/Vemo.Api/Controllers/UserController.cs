using Microsoft.AspNetCore.Mvc;
using Vemo.Application.Features.Users.Commands.User.CreateUser;
using Vemo.Application.Features.Users.Commands.User.UpdatePassword;
using Vemo.Application.Features.Users.Commands.User.UpdateUser;
using Vemo.Application.Features.Users.Commands.UserRole.CreateUserRole;
using Vemo.Application.Features.Users.Commands.UserRole.DeleteUserRole;
using Vemo.Application.Features.Users.Queries.GetUserById;
using Vemo.Application.Features.Users.Queries.UserRole.GetUserRoleById;
using Vemo.Application.Features.Users.Queries.UserRole.GetUserRoles;

namespace Vemo.Api.Controllers;

/// <summary>
/// Represents RESTful of User
/// </summary>
[Route("users")]
public class UserController : BaseController
{
    /// <summary>
    /// RegisterUser
    /// </summary>
    /// <param name="createUserCommand"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
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
    [HttpGet("{userId:guid}")]
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

    /// <summary>
    /// CreateUserRole
    /// </summary>
    /// <param name="createUserRoleCommand"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("roles")]
    public async Task<IActionResult> CreateUserRole(
        CreateUserRoleCommand createUserRoleCommand,
        CancellationToken cancellationToken)
    {
        var createdUserRole = await Mediator.Send(createUserRoleCommand, cancellationToken);
        return CreatedAtAction(nameof(GetUserRoleById), new { userRoleId = createdUserRole.Id }, createdUserRole);
    }

    /// <summary>
    /// GetUserRoles
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("roles")]
    public async Task<IActionResult> GetUserRoles(
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetUserRolesQuery(), cancellationToken));
    }

    /// <summary>
    /// GetUserRoleById
    /// </summary>
    /// <param name="userRoleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("roles/{userRoleId:guid}")]
    public async Task<IActionResult> GetUserRoleById(
        Guid userRoleId,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetUserRoleByIdQuery { UserRoleId = userRoleId }, cancellationToken));
    }

    [HttpDelete("roles/{userRoleId:guid}")]
    public async Task<IActionResult> DeleteUserRole(
        Guid userRoleId,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(new DeleteUserRoleCommand { UserRoleId = userRoleId }, cancellationToken);
        return NoContent();
    }
}