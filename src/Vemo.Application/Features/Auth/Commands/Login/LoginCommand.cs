namespace Vemo.Application.Features.Auth.Commands.Login;

/// <summary>
/// LoginCommand
/// </summary>
public class LoginCommand : IRequest<TokenResponseDto>
{
    /// <summary>
    /// Gets or sets Email
    /// </summary>
    public string Email { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets Password
    /// </summary>
    public string Password { get; set; } = string.Empty;
}