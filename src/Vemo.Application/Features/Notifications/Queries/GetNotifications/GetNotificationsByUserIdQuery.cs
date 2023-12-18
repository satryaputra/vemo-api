namespace Vemo.Application.Features.Notifications.Queries.GetNotifications;

/// <summary>
/// GetNotificationsByUserIdQuery
/// </summary>
public class GetNotificationsByUserIdQuery : IRequest<object>
{
    /// <summary>
    /// Gets or sets UserId
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets Count
    /// </summary>
    public bool? Count { get; set; }

    /// <summary>
    /// Gets or sets Unread
    /// </summary>
    public bool? Unread { get; set; }
}