namespace Vemo.Application.Features.Users.Commands.UserRole.CreateUserRole;

/// <summary>
/// CreateUserRoleCommand
/// </summary>
public class CreateUserRoleCommand : IRequest<Domain.Entities.Users.UserRole>
{
    /// <summary>
    /// Gets or sets Role
    /// </summary>
    public string Role { get; set; } = string.Empty;
}