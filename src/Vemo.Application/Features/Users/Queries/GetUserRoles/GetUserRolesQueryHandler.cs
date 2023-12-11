using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Users;

namespace Vemo.Application.Features.Users.Queries.GetUserRoles;

/// <summary>
/// GetUserRolesQueryHandler
/// </summary>
internal sealed class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, List<UserRole>>
{
    private readonly IUserRoleRepository _userRoleRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="GetUserRolesQueryHandler"/> class.
    /// </summary>
    /// <param name="userRoleRepository"></param>
    public GetUserRolesQueryHandler(IUserRoleRepository userRoleRepository)
    {
        _userRoleRepository = userRoleRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<UserRole>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
    {
        return await _userRoleRepository.GetUserRolesAsync(cancellationToken);
    }
}