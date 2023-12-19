using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Notifications.Commands.DeleteNotification;

/// <summary>
/// DeleteNotificationCommandHandler
/// </summary>
public class DeleteNotificationCommandHandler :IRequestHandler<DeleteNotificationCommand, Unit>
{
    private readonly INotificationRepository _notificationRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="DeleteNotificationCommandHandler"/> class.
    /// </summary>
    /// <param name="notificationRepository"></param>
    public DeleteNotificationCommandHandler(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
    {
        foreach (var notificationId in request.ListNotificationId)
        {
            await _notificationRepository.DeleteNotificationAsync(notificationId, cancellationToken);
        }

        return Unit.Value;
    }
}