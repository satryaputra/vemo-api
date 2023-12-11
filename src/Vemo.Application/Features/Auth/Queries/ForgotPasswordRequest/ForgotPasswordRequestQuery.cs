namespace Vemo.Application.Features.Auth.Queries.ForgotPasswordRequest;

/// <summary>
/// ForgotPasswordRequestQuery
/// </summary>
public class ForgotPasswordRequestQuery : IRequest<GenericResponseDto>
{
    /// <summary>
    /// Gets or sets Email
    /// </summary>
    public string Email { get; set; } = string.Empty;
}