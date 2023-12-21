using AutoMapper;
using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Application.Common.Utils;
using Vemo.Domain.Entities.Notifications;

namespace Vemo.Application.Features.Users.Commands.CreateUser;

/// <summary>
/// CreateUserCommandHandler
/// </summary>
internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, TokenCreateUserResponseDto>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IAuthInfoRepository _authInfoRepository;
    private readonly INotificationRepository _notificationRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="CreateUserCommandHandler"/> class.
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="userRepository"></param>
    /// <param name="authInfoRepository"></param>
    /// <param name="notificationRepository"></param>
    public CreateUserCommandHandler(
        IMapper mapper,
        IUserRepository userRepository,
        IAuthInfoRepository authInfoRepository,
        INotificationRepository notificationRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _authInfoRepository = authInfoRepository;
        _notificationRepository = notificationRepository;
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

        var newUser = _mapper.Map<Domain.Entities.Users.User>(request);

        await _userRepository.CreateUserAsync(newUser, cancellationToken);

        // Generate token
        var accessToken = TokenBuilder.CreateAccessToken(newUser.Id, newUser.Role);
        var refreshToken = TokenBuilder.CreateRefreshToken();
        var refreshTokenExpires = TokenBuilder.GetRefreshTokenExpired();

        await _authInfoRepository.AddNewRefreshTokenAsync(newUser.Id, refreshToken, refreshTokenExpires, cancellationToken);

        // Notification
        var notification = new Notification
        {
            Title = "Selamat Datang di Vemo",
            Description = "Terimakasih telah mendaftar dan mempercayakan kendaraan Anda di Vemo",
            UserId = newUser.Id
        };

        await _notificationRepository.AddNotificationAsync(notification, cancellationToken);

        return new TokenCreateUserResponseDto(newUser.Id, accessToken, refreshToken, refreshTokenExpires);
    }
}