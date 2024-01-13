namespace Vemo.Application.Features.Vehicles.Commands.ChangeMaintenancePrice;

/// <summary>
/// ChangeMaintenancePriceQuery
/// </summary>
public class ChangeMaintenancePriceQuery : IRequest<object>
{
    /// <summary>
    /// Gets or sets MaintenancePartId
    /// </summary>
    public Guid MaintenancePartId { get; set; }

    /// <summary>
    /// Gets or sets NewPrice
    /// </summary>
    public double NewPrice { get; set; }
}