using Vemo.Application.Common.Interfaces;
using Vemo.Application.Common.Utils;
using Vemo.Domain.Enums;

namespace Vemo.Application.Features.Auth.Commands.ResetPassword;

/// <summary>
/// ResetPasswordCommandHandler
/// </summary>
internal sealed class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, GenericResponseDto>
{
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="ResetPasswordCommandHandler"/> class.
    /// </summary>
    /// <param name="userRepository"></param>
    public ResetPasswordCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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
        return new GenericResponseDto("Reset password berhasil");
    }
}