namespace Vemo.Application.Features.Auth.Commands.Logout;

/// <summary>
/// LogoutCommand
/// </summary>
public class LogoutCommand : IRequest<Unit>
{
    /// <summary>
    /// Gets or sets AccessToken
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;
}