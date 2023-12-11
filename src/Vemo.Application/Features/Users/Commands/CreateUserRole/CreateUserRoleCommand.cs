using Vemo.Domain.Entities.Users;

namespace Vemo.Application.Features.Users.Commands.CreateUserRole;

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