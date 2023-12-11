using Vemo.Domain.Entities.Users;

namespace Vemo.Application.Features.Users.Queries.GetUserRoleById;

/// <summary>
/// GetUserRoleByIdQuery
/// </summary>
public class GetUserRoleByIdQuery : IRequest<UserRole>
{
    /// <summary>
    /// Gets or sets UserRoleId
    /// </summary>
    public Guid UserRoleId { get; set; }
}