namespace Vemo.Application.Features.Notifications.Commands.ReadNotification;

/// <summary>
/// ReadNotificationCommand
/// </summary>
public class ReadNotificationCommand : IRequest<GenericResponseDto>
{
    /// <summary>
    /// Gets or sets ListNotificationId
    /// </summary>
    public List<Guid> ListNotificationId { get; set; } = null!;
}