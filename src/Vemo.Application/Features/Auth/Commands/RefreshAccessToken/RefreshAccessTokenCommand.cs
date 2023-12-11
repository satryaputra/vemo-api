namespace Vemo.Application.Features.Auth.Commands.RefreshAccessToken;

/// <summary>
/// RefreshAccessTokenCommand
/// </summary>
public class RefreshAccessTokenCommand : IRequest<TokenResponseDto>
{
    /// <summary>
    /// Gets or sets AccessToken
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets RefreshToken
    /// </summary>
    public string RefreshToken { get; set; } = string.Empty;
}