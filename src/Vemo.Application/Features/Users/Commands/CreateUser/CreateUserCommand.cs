using Vemo.Application.Dtos;

namespace Vemo.Application.Features.Users.Commands.CreateUser;

/// <summary>
/// CreateUserCommand
/// </summary>
public class CreateUserCommand : IRequest<TokenResponseDto>
{
    /// <summary>
    /// Gets or sets Name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Email
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Password
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Role
    /// </summary>
    public string Role { get; set; } = string.Empty;
}