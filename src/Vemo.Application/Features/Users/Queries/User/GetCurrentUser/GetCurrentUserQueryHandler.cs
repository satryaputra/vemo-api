using AutoMapper;
using Vemo.Application.Common.Interfaces;
using Vemo.Application.Common.Utils;
using Vemo.Domain.Enums;

namespace Vemo.Application.Features.Users.Queries.User.GetCurrentUser;

internal sealed class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, UserResponseDto>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="GetCurrentUserQueryHandler"/> class.
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="userRepository"></param>
    /// <param name="userRoleRepository"></param>
    public GetCurrentUserQueryHandler(IMapper mapper, IUserRepository userRepository, IUserRoleRepository userRoleRepository)
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
    public async Task<UserResponseDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        var userId = TokenBuilder.GetUserIdFromJwtToken(request.AccessToken, TokenType.AccessToken);
        var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
        var userRole = await _userRoleRepository.GetUserRoleByIdAsync(user.UserRoleId, cancellationToken);
        var userToResponse = _mapper.Map<UserResponseDto>(user);
        userToResponse.Role = userRole.Role;
        return userToResponse;
    }
}