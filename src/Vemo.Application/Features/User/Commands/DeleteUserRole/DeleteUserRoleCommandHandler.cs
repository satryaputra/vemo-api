﻿using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.User.Commands.DeleteUserRole;

/// <summary>
/// DeleteUserRoleCommandHandler
/// </summary>
public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand, Unit>
{
    private readonly IUserRoleRepository _userRoleRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="DeleteUserRoleCommandHandler"/> class.
    /// </summary>
    /// <param name="userRoleRepository"></param>
    public DeleteUserRoleCommandHandler(IUserRoleRepository userRoleRepository)
    {
        _userRoleRepository = userRoleRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
    {
        await _userRoleRepository.DeleteRoleAsync(request.UserRoleId, cancellationToken);
        return Unit.Value;
    }
}