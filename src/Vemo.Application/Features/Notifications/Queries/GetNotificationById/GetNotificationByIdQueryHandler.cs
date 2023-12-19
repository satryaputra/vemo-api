using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Notifications;

namespace Vemo.Application.Features.Notifications.Queries.GetNotificationById;

/// <summary>
/// GetNotificationByIdQueryHandler
/// </summary>
public class GetNotificationByIdQueryHandler : IRequestHandler<GetNotificationByIdQuery, Notification>
{
    private readonly INotificationRepository _notificationRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="GetNotificationByIdQueryHandler"/> class.
    /// </summary>
    /// <param name="notificationRepository"></param>
    public GetNotificationByIdQueryHandler(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Notification> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
    {
        return await _notificationRepository.GetNotificationByIdAsync(request.NotificationId, cancellationToken);
    }
}