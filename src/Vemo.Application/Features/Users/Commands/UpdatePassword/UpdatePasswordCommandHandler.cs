using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Application.Common.Utils;
using Vemo.Domain.Entities.Notifications;

namespace Vemo.Application.Features.Users.Commands.UpdatePassword;

/// <summary>
/// UpdatePasswordCommandHandler
/// </summary>
internal sealed class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, GenericResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly INotificationRepository _notificationRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="UpdatePasswordCommandHandler"/> class.
    /// </summary>
    /// <param name="userRepository"></param>
    /// <param name="notificationRepository"></param>
    public UpdatePasswordCommandHandler(
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
    /// <exception cref="BadRequestException"></exception>
    public async Task<GenericResponseDto> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.UserId, cancellationToken);
        
        if (!PasswordHasher.VerifyPassword(request.OldPassword, user.Password))
        {
            throw new BadRequestException("Password salah");
        }

        if (request.OldPassword.Equals(request.NewPassword))
        {
            throw new BadRequestException("Password baru tidak boleh sama dengan sebelumnya");
        }

        await _userRepository.UpdatePasswordAsync(user.Id, request.NewPassword, cancellationToken);

        // Notification
        var notification = new Notification
        {
            Title = "Ubah Password",
            Description = "Selamat! Anda telah berhasil mengubah password akun Anda",
            UserId = request.UserId
        };

        await _notificationRepository.AddNotificationAsync(notification, cancellationToken);

        return new GenericResponseDto("Update password berhasil");
    }
}