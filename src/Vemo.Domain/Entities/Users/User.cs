using System.Text.Json.Serialization;
using Vemo.Domain.Common;
using Vemo.Domain.Entities.Vehicles;

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
    /// Gets or sets Role
    /// </summary>
    public string Role { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets UserAuthInfo
    /// </summary>
    [JsonIgnore]
    public UserAuthInfo? UserAuthInfo { get; init; }

    /// <summary>
    /// Gets or sets Vehicles
    /// </summary>
    [JsonIgnore]
    public List<Vehicle>? Vehicles { get; set; }
}