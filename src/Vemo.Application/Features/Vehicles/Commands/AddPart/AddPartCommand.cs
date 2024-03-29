﻿namespace Vemo.Application.Features.Vehicles.Commands.AddPart;

/// <summary>
/// AddVehiclePartCommand
/// </summary>
public class AddPartVehicleCommand : IRequest<Guid>
{
    /// <summary>
    /// Gets or sets Name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets AgeInMonth
    /// </summary>
    public int AgeInMonth { get; set; }

    /// <summary>
    /// Gets or sets MaintenancePrice
    /// </summary>
    public double MaintenancePrice { get; set; }

    /// <summary>
    /// Gets or sets MaintenanceServicePrice
    /// </summary>
    public double MaintenanceServicePrice { get; set; }

    /// <summary>
    /// Gets or sets VehicleType
    /// </summary>
    public string? VehicleType { get; set; }
}