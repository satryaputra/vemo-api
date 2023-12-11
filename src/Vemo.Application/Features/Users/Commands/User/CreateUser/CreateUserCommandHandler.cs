using AutoMapper;
using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Application.Common.Utils;

namespace Vemo.Application.Features.Users.Commands.User.CreateUser;

/// <summary>
/// CreateUserCommandHandler
/// </summary>
internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, TokenCreateUserResponseDto>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUserAuthInfoRepository _userAuthInfoRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="CreateUserCommandHandler"/> class.
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="userRepository"></param>
    /// <param name="userRoleRepository"></param>
    /// <param name="userAuthInfoRepository"></param>
    public CreateUserCommandHandler(
        IMapper mapper, 
        IUserRepository userRepository, 
        IUserRoleRepository userRoleRepository, 
        IUserAuthInfoRepository userAuthInfoRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
        _userAuthInfoRepository = userAuthInfoRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ConflictException"></exception>
    public async Task<TokenCreateUserResponseDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.IsUserExistsByEmailAsync(request.Email, cancellationToken))
        {
            throw new ConflictException("Email sudah terdaftar");
        }
        
        var userRole = await _userRoleRepository.GetUserRoleByRoleAsync(request.Role, cancellationToken);
        
        var newUser = _mapper.Map<Domain.Entities.Users.User>(request);
        newUser.UserRoleId = userRole.Id;

        await _userRepository.CreateUserAsync(newUser, cancellationToken);
        
        var accessToken = TokenBuilder.CreateAccessToken(newUser.Id, userRole.Role);
        var refreshToken = TokenBuilder.CreateRefreshToken();
        var refreshTokenExpires = TokenBuilder.GetRefreshTokenExpired();
;
        await _userAuthInfoRepository.AddNewRefreshTokenAsync(newUser.Id, refreshToken, refreshTokenExpires, cancellationToken);

        return new TokenCreateUserResponseDto(newUser.Id, accessToken, refreshToken, refreshTokenExpires);
    }
}