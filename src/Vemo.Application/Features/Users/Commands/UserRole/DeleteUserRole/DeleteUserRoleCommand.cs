namespace Vemo.Application.Features.Users.Commands.UserRole.DeleteUserRole;

/// <summary>
/// DeleteUserRoleCommand
/// </summary>
public class DeleteUserRoleCommand : IRequest<Unit>
{
    /// <summary>
    /// Gets or sets UserRoleId
    /// </summary>
    public Guid UserRoleId { get; set; }
}