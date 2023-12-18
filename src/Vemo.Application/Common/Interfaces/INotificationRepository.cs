using Vemo.Domain.Entities.Notifications;

namespace Vemo.Application.Common.Interfaces;

/// <summary>
/// INotificationRepository
/// </summary>
public interface INotificationRepository
{
    /// <summary>
    /// AddNotificationAsync
    /// </summary>
    /// <param name="notification"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddNotificationAsync(Notification notification, CancellationToken cancellationToken);

    /// <summary>
    /// GetNotificationsByUserIAsync
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<Notification>> GetNotificationsByUserIAsync(Guid userId, CancellationToken cancellationToken);
    
    /// <summary>
    /// GetNotificationByIdAsync
    /// </summary>
    /// <param name="notificationId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Notification> GetNotificationByIdAsync(Guid notificationId, CancellationToken cancellationToken);

    /// <summary>
    /// CountNotificationByUserIdAsync
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> CountNotificationByUserIdAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// ReadNotificationAsync
    /// </summary>
    /// <param name="notificationId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task ReadNotificationAsync(Guid notificationId, CancellationToken cancellationToken);

    /// <summary>
    /// DeleteNotificationAsync
    /// </summary>
    /// <param name="notificationId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteNotificationAsync(Guid notificationId, CancellationToken cancellationToken);
}