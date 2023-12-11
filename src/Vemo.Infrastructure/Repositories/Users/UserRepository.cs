﻿using Microsoft.EntityFrameworkCore;
using Vemo.Application.Common.Exceptions;
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
    /// GetUserIdByIdAsync
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<User> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _context.Users.FindAsync(new object?[] { userId }, cancellationToken)
               ?? throw new NotFoundException("User tidak ditemukan | GetUserByEmailAsync");
    }

    /// <summary>
    /// GetUserByEmailAsync
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email), cancellationToken)
               ?? throw new NotFoundException("User tidak ditemukan | GetUserByEmailAsync");
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