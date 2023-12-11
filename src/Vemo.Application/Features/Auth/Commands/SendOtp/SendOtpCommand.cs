namespace Vemo.Application.Features.Auth.Commands.SendOtp;

/// <summary>
/// SendOtpCommand
/// </summary>
public class SendOtpCommand : IRequest<GenericResponseDto>
{
    /// <summary>
    /// Gets or sets AccessToken
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Email
    /// </summary>
    public string Email { get; set; } = string.Empty;
}