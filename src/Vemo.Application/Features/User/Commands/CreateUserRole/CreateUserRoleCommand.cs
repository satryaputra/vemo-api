using Vemo.Domain.Entities.User;

namespace Vemo.Application.Features.User.Commands.CreateUserRole;

/// <summary>
/// CreateUserRoleCommand
/// </summary>
public class CreateUserRoleCommand : IRequest<UserRole>
{
    /// <summary>
    /// Gets or sets Role
    /// </summary>
    public string Role { get; set; } = string.Empty;
}