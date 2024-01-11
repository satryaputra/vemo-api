namespace Vemo.Application.Features.Vehicles.Queries.GetMaintenanceByVehicleId;

/// <summary>
/// GetMaintenanceByVehicleIdQuery
/// </summary>
public class GetMaintenanceByVehicleIdQuery : IRequest<object>
{
    /// <summary>
    /// Gets or sets VehicleId
    /// </summary>
    public Guid VehicleId { get; set; }
}