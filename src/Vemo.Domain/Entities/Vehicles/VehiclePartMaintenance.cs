﻿using Vemo.Domain.Common;

namespace Vemo.Domain.Entities.Vehicles;

/// <summary>
/// VehiclePartMaintenance
/// </summary>
public class VehiclePartMaintenance : BaseEntity
{
    /// <summary>
    /// Gets or sets LastMaintenance
    /// </summary>
    public DateTime LastMaintenance { get; set; }

    /// <summary>
    /// Gets or sets NextMaintenance
    /// </summary>
    public DateTime NextMaintenance { get; set; }

    /// <summary>
    /// Gets or sets Vehicle
    /// </summary>
    public Vehicle Vehicle { get; set; } = null!;

    /// <summary>
    /// Gets or sets VehicleId
    /// </summary>
    public Guid VehicleId { get; set; }

    /// <summary>
    /// Gets or sets VehiclePart
    /// </summary>
    public VehiclePart VehiclePart { get; set; } = null!;

    /// <summary>
    /// Gets or sets VehiclePartId
    /// </summary>
    public Guid VehiclePartId { get; set; }
}