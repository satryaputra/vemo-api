namespace Vemo.Application.Features.Auth.Queries.ResetPasswordRequest;

/// <summary>
/// ResetPasswordRequestQuery
/// </summary>
public class ResetPasswordRequestQuery : IRequest<GenericResponseDto>
{
    /// <summary>
    /// Gets or sets Email
    /// </summary>
    public string Email { get; set; } = string.Empty;
}