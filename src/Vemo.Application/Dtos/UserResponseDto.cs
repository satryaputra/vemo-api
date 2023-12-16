namespace Vemo.Application.Dtos;

/// <summary>
/// ResponseUser
/// </summary>
public class UserResponseDto
{
    /// <summary>
    /// Gets or sets Id
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets Name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Email
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Role
    /// </summary>
    public string Role { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Photo
    /// </summary>
    public string Photo { get; set; } = string.Empty;
}