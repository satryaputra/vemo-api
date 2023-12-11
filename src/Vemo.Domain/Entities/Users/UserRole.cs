using System.Text.Json.Serialization;
using Vemo.Domain.Common;

namespace Vemo.Domain.Entities.Users;

/// <summary>
/// UserRole
/// </summary>
public class UserRole : BaseEntity
{
    /// <summary>
    /// Gets or sets Role
    /// </summary>
    public string Role { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Users
    /// </summary>
    [JsonIgnore]
    public List<User>? Users { get; set; }
}