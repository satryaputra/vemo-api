namespace Vemo.Application.Features.Vehicles.Commands.UpdatePart;

public class UpdatePartCommand : IRequest<object>
{
    public Guid PartId{ get; set; }
    
    /// <summary>
    /// Gets or sets Name
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets AgeInMonth
    /// </summary>
    public int? AgeInMonth { get; set; }

    /// <summary>
    /// Gets or sets MaintenancePrice
    /// </summary>
    public double? MaintenancePrice { get; set; }

    /// <summary>
    /// Gets or sets MaintenanceServicePrice
    /// </summary>
    public double? MaintenanceServicePrice { get; set; }

    /// <summary>
    /// Gets or sets VehicleType
    /// </summary>
    public string? VehicleType { get; set; }
}