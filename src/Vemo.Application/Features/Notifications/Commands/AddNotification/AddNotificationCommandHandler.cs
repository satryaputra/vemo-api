using AutoMapper;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Notifications;

namespace Vemo.Application.Features.Notifications.Commands.AddNotification;

internal sealed class AddNotificationCommandHandler : IRequestHandler<AddNotificationCommand, GenericResponseDto>
{
    private readonly IMapper _mapper;
    private readonly INotificationRepository _notificationRepository;

    public AddNotificationCommandHandler(IMapper mapper, INotificationRepository notificationRepository)
    {
        _mapper = mapper;
        _notificationRepository = notificationRepository;
    }

    public async Task<GenericResponseDto> Handle(AddNotificationCommand request, CancellationToken cancellationToken)
    {
        var notification = _mapper.Map<Notification>(request);
        await _notificationRepository.AddNotificationAsync(notification, cancellationToken);
        return new GenericResponseDto("Berhasil menambahkan notification");
    }
}