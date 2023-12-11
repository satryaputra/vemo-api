using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Application.Common.Utils;

namespace Vemo.Application.Features.Users.Commands.User.UpdatePassword;

/// <summary>
/// UpdatePasswordCommandHandler
/// </summary>
internal sealed class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, GenericResponseDto>
{
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="UpdatePasswordCommandHandler"/> class.
    /// </summary>
    /// <param name="userRepository"></param>
    public UpdatePasswordCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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

        return new GenericResponseDto("Update password berhasil");
    }
}