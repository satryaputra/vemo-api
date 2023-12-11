using Vemo.Domain.Common;

namespace Vemo.Domain.Entities.Users;

/// <summary>
/// User
/// </summary>
public class User : BaseAuditableEntity
{
    /// <summary>
    /// Gets or sets Name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Email
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Password
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets UserRole
    /// </summary>
    public UserRole UserRole { get; set; } = null!;

    /// <summary>
    /// Gets or sets UserRoleId
    /// </summary>
    public Guid UserRoleId { get; set; }

    /// <summary>
    /// Gets or sets UserAuthInfo
    /// </summary>
    public UserAuthInfo? UserAuthInfo { get; set; }
}