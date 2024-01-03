using AutoMapper;
using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Users.Queries.GetAllUsers;

/// <summary>
/// GetAllUsersQueryHandler
/// </summary>
internal sealed class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="GetAllUsersQueryHandler"/> class.
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="userRepository"></param>
    public GetAllUsersQueryHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<UserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllUsersAsync(cancellationToken);
        return _mapper.Map<List<UserResponseDto>>(users);
    }
}