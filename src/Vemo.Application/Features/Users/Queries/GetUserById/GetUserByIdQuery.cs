namespace Vemo.Application.Features.Users.Queries.GetUserById;

/// <summary>
/// GetUserByIdQuery
/// </summary>
public class GetUserByIdQuery : IRequest<UserResponseDto>
{
    /// <summary>
    /// Gets or sets UserId
    /// </summary>
    public Guid UserId { get; set; }
}