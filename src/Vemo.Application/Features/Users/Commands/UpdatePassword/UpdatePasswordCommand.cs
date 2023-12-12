namespace Vemo.Application.Features.Users.Commands.UpdatePassword;

/// <summary>
/// UpdatePasswordCommand
/// </summary>
public class UpdatePasswordCommand : IRequest<GenericResponseDto>
{
    /// <summary>
    /// Gets or sets UserId
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Gets or sets OldPassword
    /// </summary>
    public string OldPassword { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets NewPassword
    /// </summary>
    public string NewPassword { get; set; } = string.Empty;
}