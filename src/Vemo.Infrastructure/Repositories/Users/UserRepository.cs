using Microsoft.EntityFrameworkCore;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Users;

namespace Vemo.Infrastructure.Repositories.Users;

/// <summary>
/// UserRepository
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// Initialize a new instance of the <see cref="UserRepository"/> class.
    /// </summary>
    /// <param name="context"></param>
    public UserRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// CreateUserAsync
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    public async Task CreateUserAsync(User user, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// IsUserExistsByEmailAsync
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> IsUserExistsByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Users.AnyAsync(u => u.Email.Equals(email), cancellationToken);
    }
}