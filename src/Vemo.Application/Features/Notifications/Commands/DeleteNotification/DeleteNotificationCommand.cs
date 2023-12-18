namespace Vemo.Application.Features.Notifications.Commands.DeleteNotification;

/// <summary>
/// DeleteNotificationCommand
/// </summary>
public class DeleteNotificationCommand : IRequest<Unit>
{
    /// <summary>
    /// Gets or sets UserId
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Gets or sets ListNotificationId
    /// </summary>
    public List<Guid> ListNotificationId { get; set; } = null!;
}