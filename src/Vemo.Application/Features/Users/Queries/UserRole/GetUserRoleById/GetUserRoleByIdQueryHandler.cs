using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Users.Queries.UserRole.GetUserRoleById;

/// <summary>
/// GetUserRoleByIdQueryHandler
/// </summary>
internal sealed class GetUserRoleByIdQueryHandler : IRequestHandler<GetUserRoleByIdQuery, Domain.Entities.Users.UserRole>
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
    public async Task<Domain.Entities.Users.UserRole> Handle(GetUserRoleByIdQuery request, CancellationToken cancellationToken)
    {
        return await _userRoleRepository.GetUserRoleByIdAsync(request.UserRoleId, cancellationToken);
    }
}