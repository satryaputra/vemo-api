using AutoMapper;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Users;

namespace Vemo.Application.Features.Users.Queries.GetActiveUsers;

/// <summary>
/// GetActiveUsersQueryHandler
/// </summary>
internal sealed class GetActiveUsersQueryHandler : IRequestHandler<GetActiveUsersQuery, List<UserResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly ICacheService _cacheService;

    /// <summary>
    /// Initialize a new instance of the <see cref="GetActiveUsersQueryHandler"/> class.
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="userRepository"></param>
    /// <param name="cacheService"></param>
    public GetActiveUsersQueryHandler(
        IMapper mapper,
        IUserRepository userRepository,
        ICacheService cacheService)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _cacheService = cacheService;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<UserResponseDto>> Handle(GetActiveUsersQuery request, CancellationToken cancellationToken)
    {
        var userIds = await _cacheService.GetActiveUsersAsync();
        var users = new List<User>();
        foreach (var userId in userIds)   
        {
            var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
            users.Add(user);
        }
        return _mapper.Map<List<UserResponseDto>>(users);
    }
}