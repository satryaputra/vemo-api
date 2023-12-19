using Microsoft.EntityFrameworkCore;
using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Notifications;

namespace Vemo.Infrastructure.Repositories.Notifications;

/// <summary>
/// NotificationRepository
/// </summary>
public class NotificationRepository : INotificationRepository
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Initialize a new instance of the <see cref="NotificationRepository"/> class.
    /// </summary>
    /// <param name="context"></param>
    public NotificationRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// AddNotificationAsync
    /// </summary>
    /// <param name="notification"></param>
    /// <param name="cancellationToken"></param>
    public async Task AddNotificationAsync(Notification notification, CancellationToken cancellationToken)
    {
        await _context.Notifications.AddAsync(notification, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// GetNotificationsByUserIAsync
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<Notification>> GetNotificationsByUserIAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _context.Notifications.Where(n => n.UserId.Equals(userId))
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// GetNotificationByIdAsync
    /// </summary>
    /// <param name="notificationId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<Notification> GetNotificationByIdAsync(Guid notificationId, CancellationToken cancellationToken)
    {
        return await _context.Notifications.FindAsync(new object?[] { notificationId }, cancellationToken)
               ?? throw new NotFoundException("Pemberitahuan tidak ditemukan | GetNotificationByIdAsync");
    }

    /// <summary>
    /// CountNotificationByUserIdAsync
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> CountNotificationByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var notifications = await GetNotificationsByUserIAsync(userId, cancellationToken);
        return notifications.Count;
    }

    /// <summary>
    /// ReadNotificationAsync
    /// </summary>
    /// <param name="notificationId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task ReadNotificationAsync(Guid notificationId, CancellationToken cancellationToken)
    {
        var notification = await GetNotificationByIdAsync(notificationId, cancellationToken);
        notification.Read = true;
        await _context.SaveChangesAsync(cancellationToken);
    }

     /// <summary>
     /// DeleteNotificationAsync
     /// </summary>
     /// <param name="notificationId"></param>
     /// <param name="cancellationToken"></param>
    public async Task DeleteNotificationAsync(Guid notificationId, CancellationToken cancellationToken)
    {
        var notification = await GetNotificationByIdAsync(notificationId, cancellationToken);
        _context.Notifications.Remove(notification);
        await _context.SaveChangesAsync(cancellationToken);
    }
}