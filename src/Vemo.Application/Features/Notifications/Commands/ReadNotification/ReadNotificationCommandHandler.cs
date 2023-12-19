using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Notifications.Commands.ReadNotification;

/// <summary>
/// ReadNotificationCommandHandler
/// </summary>
public class ReadNotificationCommandHandler : IRequestHandler<ReadNotificationCommand, GenericResponseDto>
{
    private readonly INotificationRepository _notificationRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="ReadNotificationCommandHandler"/> class.
    /// </summary>
    /// <param name="notificationRepository"></param>
    public ReadNotificationCommandHandler(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GenericResponseDto> Handle(ReadNotificationCommand request, CancellationToken cancellationToken)
    {
        foreach (var notificationId in request.ListNotificationId)
        {
            await _notificationRepository.ReadNotificationAsync(notificationId, cancellationToken);
        }
        return new GenericResponseDto("Berhasil mengubah status read notification");
    }
}