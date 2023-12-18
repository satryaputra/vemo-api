namespace Vemo.Application.Features.Notifications.Commands.ReadNotification;

/// <summary>
/// ReadNotificationCommand
/// </summary>
public class ReadNotificationCommand : IRequest<GenericResponseDto>
{
    /// <summary>
    /// Gets or sets NotificationId
    /// </summary>
    public Guid NotificationId { get; set; }
}