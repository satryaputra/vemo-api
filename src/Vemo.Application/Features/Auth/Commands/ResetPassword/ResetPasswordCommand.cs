namespace Vemo.Application.Features.Auth.Commands.ResetPassword;

/// <summary>
/// ResetPasswordCommand
/// </summary>
public class ResetPasswordCommand : IRequest<GenericResponseDto>
{
    /// <summary>
    /// Gets or sets Token
    /// </summary>
    public string Token { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets NewPassword
    /// </summary>
    public string NewPassword { get; set; } = string.Empty;
}