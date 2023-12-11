namespace Vemo.Application.Features.Auth.Queries.VerifyOtp;

/// <summary>
/// VerifyOtpQuery
/// </summary>
public class VerifyOtpQuery : IRequest<GenericResponseDto>
{
    /// <summary>
    /// Gets or sets AccessToken
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Otp
    /// </summary>
    public int Otp { get; set; }
}