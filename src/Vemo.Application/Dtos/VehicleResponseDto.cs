﻿namespace Vemo.Application.Dtos;

/// <summary>
/// VehicleResponseDto
/// </summary>
public class VehicleResponseDto
{
    /// <summary>
    /// Gets or sets VehicleId
    /// </summary>
    public Guid VehicleId { get; set; }
    
    /// <summary>
    /// Gets or sets VehicleName
    /// </summary>
    public string VehicleName { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets OwnerName
    /// </summary>
    public string OwnerName { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets PurchasingDate
    /// </summary>
    public DateTime PurchasingDate { get; set; }
    
    /// <summary>
    /// Gets or sets LicencePlate
    /// </summary>
    public string LicensePlate { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets VehicleType
    /// </summary>
    public string VehicleType { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets Status
    /// </summary>
    public string Status { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets MaintenanceStatus
    /// </summary>
    public string MaintenanceStatus { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets Condition
    /// </summary>
    public double Condition { get; set; }
    
    /// <summary>
    /// Gets or sets UserId
    /// </summary>
    public Guid UserId { get; set; }
}