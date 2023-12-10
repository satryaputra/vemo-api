namespace Vemo.Application.Features.User.Commands.DeleteUserRole;

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