using Vemo.Domain.Entities.User;

namespace Vemo.Application.Features.User.Queries.GetUserRoleById;

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