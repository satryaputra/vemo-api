namespace Vemo.Application.Features.Auth.Queries.VerifyPassword;

/// <summary>
/// VerifyPasswordQuery
/// </summary>
public class VerifyPasswordQuery : IRequest<GenericResponseDto>
{
    /// <summary>
    /// Gets or sets AccessToken
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Password
    /// </summary>
    public string Password { get; set; } = string.Empty;
}