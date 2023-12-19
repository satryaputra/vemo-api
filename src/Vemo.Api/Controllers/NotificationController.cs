using Org.BouncyCastle.Crypto.Engines;
using Vemo.Application.Features.Notifications.Commands.AddNotification;
using Vemo.Application.Features.Notifications.Commands.DeleteNotification;
using Vemo.Application.Features.Notifications.Commands.ReadNotification;
using Vemo.Application.Features.Notifications.Queries.GetNotificationById;
using Vemo.Application.Features.Notifications.Queries.GetNotifications;

namespace Vemo.Api.Controllers;

/// <summary>
/// Represents RESTful of Notification
/// </summary>
[Route("notifications"), Authorize]
public class NotificationController : BaseController
{
    /// <summary>
    /// AddNotification
    /// </summary>
    /// <param name="addNotificationCommand"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AddNotification(
        AddNotificationCommand addNotificationCommand,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(addNotificationCommand, cancellationToken));
    }

    /// <summary>
    /// GetNotificationsByUserId
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <param name="count"></param>
    /// <param name="unread"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetNotificationsByUserId(
        CancellationToken cancellationToken,
        [FromQuery] bool? count = null,
        [FromQuery] bool? unread = null
    )
    {
        return Ok(await Mediator.Send(new GetNotificationsByUserIdQuery
        {
            AccessToken = GetAccessTokenFromHeader(),
            Count = count,
            Unread = unread
        }, cancellationToken));
    }

    /// <summary>
    /// GetNotificationById
    /// </summary>
    /// <param name="notificationId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{notificationId:guid}")]
    public async Task<IActionResult> GetNotificationById(
        [FromRoute] Guid notificationId,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetNotificationByIdQuery
            {
                NotificationId = notificationId
            },
            cancellationToken));
    }

    [HttpPost("read")]
    public async Task<IActionResult> ReadNotification(
        ReadNotificationCommand readNotificationCommand,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(readNotificationCommand, cancellationToken));
    }

    /// <summary>
    /// DeleteNotifications
    /// </summary>
    /// <param name="deleteNotificationCommand"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> DeleteNotifications(
        DeleteNotificationCommand deleteNotificationCommand,
        CancellationToken cancellationToken)
    {
        await Mediator.Send(deleteNotificationCommand, cancellationToken);
        return NoContent();
    }
}