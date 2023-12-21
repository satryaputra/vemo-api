using Vemo.Application.Common.Interfaces;
using Vemo.Application.Common.Utils;
using Vemo.Domain.Entities.Notifications;
using Vemo.Domain.Enums;

namespace Vemo.Application.Features.Auth.Commands.ResetPassword;

/// <summary>
/// ResetPasswordCommandHandler
/// </summary>
internal sealed class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, GenericResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly INotificationRepository _notificationRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="ResetPasswordCommandHandler"/> class.
    /// </summary>
    /// <param name="userRepository"></param>
    /// <param name="notificationRepository"></param>
    public ResetPasswordCommandHandler(
        IUserRepository userRepository, 
        INotificationRepository notificationRepository)
    {
        _userRepository = userRepository;
        _notificationRepository = notificationRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GenericResponseDto> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var userId = TokenBuilder.GetUserIdFromJwtToken(request.Token, TokenType.ForgotPasswordToken);
        await _userRepository.UpdatePasswordAsync(userId, request.NewPassword, cancellationToken);
        
        // Notification
        var notification = new Notification
        {
            Title = "Reset Password",
            Description = "Selamat!, Anda telah berhasil untuk merest password akun Anda.",
            UserId = userId
        };

        await _notificationRepository.AddNotificationAsync(notification, cancellationToken);
        
        return new GenericResponseDto("Reset password berhasil");
    }
}