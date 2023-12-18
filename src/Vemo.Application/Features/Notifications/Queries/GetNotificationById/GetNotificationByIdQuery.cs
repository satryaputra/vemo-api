using Vemo.Domain.Entities.Notifications;

namespace Vemo.Application.Features.Notifications.Queries.GetNotificationById;

/// <summary>
/// GetNotificationByIdQuery
/// </summary>
public class GetNotificationByIdQuery : IRequest<Notification>
{
    /// <summary>
    /// Gets or sets NotificationId
    /// </summary>
    public Guid NotificationId { get; set; }
}