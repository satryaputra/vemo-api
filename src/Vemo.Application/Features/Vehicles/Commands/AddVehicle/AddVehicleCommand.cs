namespace Vemo.Application.Features.Vehicles.Commands.AddVehicle;

/// <summary>
/// AddVehicleCommand
/// </summary>
public class AddVehicleCommand : IRequest<Guid>
{
    /// <summary>
    /// Gets or sets VehicleName
    /// </summary>
    public string VehicleName { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets OwnerName
    /// </summary>
    public string OwnerName { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets LicenseNumber
    /// </summary>
    public string LicensePlate { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets PurchasingTime
    /// </summary>
    public string PurchasingDate { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets VehicleType
    /// </summary>
    public string VehicleType { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets UserId
    /// </summary>
    public Guid UserId { get; set; }
}