namespace Vemo.Application.Features.Users.Commands.UpdateUser;

/// <summary>
/// UpdateUserCommand
/// </summary>
public class UpdateUserCommand : IRequest<GenericResponseDto>
{
    /// <summary>
    /// Gets or sets UserId
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets Name
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Gets or sets Email
    /// </summary>
    public string? Email { get; set; }
}