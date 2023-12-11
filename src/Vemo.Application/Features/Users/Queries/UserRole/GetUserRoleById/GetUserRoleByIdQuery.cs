namespace Vemo.Application.Features.Users.Queries.UserRole.GetUserRoleById;

/// <summary>
/// GetUserRoleByIdQuery
/// </summary>
public class GetUserRoleByIdQuery : IRequest<Domain.Entities.Users.UserRole>
{
    /// <summary>
    /// Gets or sets UserRoleId
    /// </summary>
    public Guid UserRoleId { get; set; }
}