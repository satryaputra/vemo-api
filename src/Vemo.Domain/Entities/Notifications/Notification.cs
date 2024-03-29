﻿using System.Text.Json.Serialization;
using Vemo.Domain.Common;
using Vemo.Domain.Entities.Users;

namespace Vemo.Domain.Entities.Notifications;

/// <summary>
/// Notifications
/// </summary>
public class Notification : BaseEntity
{
    /// <summary>
    /// Gets or sets Title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Description
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets IsBool
    /// </summary>
    public bool Read { get; set; } = false;

    /// <summary>
    /// Gets or sets Category
    /// </summary>
    public string Category { get; set; } = "system";

    /// <summary>
    /// Gets or sets CreatedAt
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [JsonIgnore] public User User { get; set; } = null!;

    /// <summary>
    /// Gets or sets UserId
    /// </summary>
    public Guid? UserId { get; set; }
}