using AutoMapper;
using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Users.Queries.GetUserById;

/// <summary>
/// GetUserByIdQueryHandler
/// </summary>
internal sealed class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponseDto>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="GetUserByIdQueryHandler"/> class.
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="userRepository"></param>
    /// <param name="userRoleRepository"></param>
    public GetUserByIdQueryHandler(IMapper mapper, IUserRepository userRepository, IUserRoleRepository userRoleRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<UserResponseDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.UserId, cancellationToken);
        var userRole = await _userRoleRepository.GetUserRoleByIdAsync(user.UserRoleId, cancellationToken);
        var userToResponse = _mapper.Map<UserResponseDto>(user);
        userToResponse.Role = userRole.Role;
        return userToResponse;
    }
}