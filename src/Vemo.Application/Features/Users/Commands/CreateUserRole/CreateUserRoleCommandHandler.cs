using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Users;

namespace Vemo.Application.Features.Users.Commands.CreateUserRole;

/// <summary>
/// CreateUserRoleCommandHandler
/// </summary>
internal sealed class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, UserRole>
{
    private readonly IUserRoleRepository _userRoleRepository;
    
    /// <summary>
    /// Initialize a new instance of the <see cref="CreateUserRoleCommandHandler"/> class.
    /// </summary>
    /// <param name="userRoleRepository"></param>
    public CreateUserRoleCommandHandler(IUserRoleRepository userRoleRepository)
    {
        _userRoleRepository = userRoleRepository;
    }
    
    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<UserRole> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        return await _userRoleRepository.CreateUserRoleAsync(request.Role, cancellationToken);
    }
}