using Org.BouncyCastle.Asn1.Ocsp;
using Vemo.Application.Common.Interfaces;
using Vemo.Application.Common.Utils;
using Vemo.Domain.Enums;

namespace Vemo.Application.Features.Notifications.Queries.GetNotifications;

/// <summary>
/// GetNotificationsByUserIdQueryHandler
/// </summary>
internal sealed class GetNotificationsByUserIdQueryHandler : IRequestHandler<GetNotificationsByUserIdQuery, object>
{
    private readonly INotificationRepository _notificationRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="GetNotificationsByUserIdQueryHandler"/> class.
    /// </summary>
    /// <param name="notificationRepository"></param>
    public GetNotificationsByUserIdQueryHandler(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<object> Handle(GetNotificationsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var userId = TokenBuilder.GetUserIdFromJwtToken(request.AccessToken, TokenType.AccessToken);

        if (request.Count is null && request.Unread is null)
        {
            return await _notificationRepository.GetNotificationsByUserIAsync(userId, cancellationToken);
        }
        else if (request.Count is not null && request.Unread is not null)
        {
            var notification = await _notificationRepository.GetNotificationsByUserIAsync(userId, cancellationToken);
            return notification.Count(n => n.Read.Equals(false));
        }
        else
        {
            return await _notificationRepository.CountNotificationByUserIdAsync(userId, cancellationToken);
        }
    }
}