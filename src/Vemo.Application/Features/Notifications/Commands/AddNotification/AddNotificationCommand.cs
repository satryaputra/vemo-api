namespace Vemo.Application.Features.Notifications.Commands.AddNotification;

public class AddNotificationCommand : IRequest<GenericResponseDto>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}