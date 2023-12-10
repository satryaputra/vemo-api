using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.User;

namespace Vemo.Application.Features.User.Queries.GetUserRoleById;

/// <summary>
/// GetUserRoleByIdQueryHandler
/// </summary>
public class GetUserRoleByIdQueryHandler : IRequestHandler<GetUserRoleByIdQuery, UserRole>
{
    private readonly IUserRoleRepository _userRoleRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="GetUserRoleByIdQueryHandler"/> class.
    /// </summary>
    /// <param name="userRoleRepository"></param>
    public GetUserRoleByIdQueryHandler(IUserRoleRepository userRoleRepository)
    {
        _userRoleRepository = userRoleRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<UserRole> Handle(GetUserRoleByIdQuery request, CancellationToken cancellationToken)
    {
        return await _userRoleRepository.GetUserRoleByIdAsync(request.UserRoleId, cancellationToken);
    }
}