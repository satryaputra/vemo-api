using Vemo.Application.Common.Utils;
using Vemo.Application.Features.Users.Commands.CreateUser;
using Vemo.Application.Features.Users.Commands.UpdatePassword;
using Vemo.Application.Features.Users.Commands.UpdatePhotoProfile;
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

    /// <summary>
    /// GetCurrentUser
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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

    /// <summary>
    /// UploadImage
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    [HttpPatch("photo"), AllowAnonymous]
    public async Task<IActionResult> UploadImage([FromForm] IFormFile image)
    {
        var updatePhotoResponse = await Mediator.Send(new UpdatePhotoProfileCommand
        {
            AccessToken = GetAccessTokenFromHeader(),
            ImageName = image.FileName,
        });
        
        var imagePath = Path.Combine("/app/PhotoProfile", image.FileName);
        await using (var stream = new FileStream(imagePath, FileMode.Create))
        {
            await image.CopyToAsync(stream);
        }

        return Ok(updatePhotoResponse);
    }
}