using Microsoft.AspNetCore.Mvc;
using Vemo.Application.Features.User.Commands.CreateUserRole;
using Vemo.Application.Features.User.Commands.DeleteUserRole;
using Vemo.Application.Features.User.Queries.GetUserRoleById;
using Vemo.Application.Features.User.Queries.GetUserRoles;
using Vemo.Domain.Entities.User;

namespace Vemo.Api.Controllers;

/// <summary>
/// Represents RESTful of User
/// </summary>
[Route("users")]
public class UserController : BaseController
{
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