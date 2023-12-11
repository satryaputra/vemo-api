using Vemo.Domain.Common;

namespace Vemo.Domain.Entities.Users;

/// <summary>
/// UserAuthInfo
/// </summary>
public class UserAuthInfo : BaseEntity
{
    /// <summary>
    /// Gets or sets RefreshToken
    /// </summary>
    public string? RefreshToken { get; set; }
    
    /// <summary>
    /// Gets or sets RefreshTokenExpires
    /// </summary>
    public DateTime? RefreshTokenExpires { get; set; }

    /// <summary>
    /// Gets or sets Otp
    /// </summary>
    public int? Otp { get; set; }

    /// <summary>
    /// Gets or sets OtpExpires
    /// </summary>
    public DateTime? OtpExpires { get; set; }

    /// <summary>
    /// Gets or sets User
    /// </summary>
    public Users.User User { get; set; } = null!;

    /// <summary>
    /// Gets or sets UserId
    /// </summary>
    public Guid UserId { get; set; }
}