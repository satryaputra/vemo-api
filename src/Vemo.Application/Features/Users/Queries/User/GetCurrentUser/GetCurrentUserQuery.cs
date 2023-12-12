namespace Vemo.Application.Features.Users.Queries.User.GetCurrentUser;

/// <summary>
/// GetCurrentUserQuery
/// </summary>
public class GetCurrentUserQuery : IRequest<UserResponseDto>
{
    /// <summary>
    /// Gets or sets AccessToken
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;
}