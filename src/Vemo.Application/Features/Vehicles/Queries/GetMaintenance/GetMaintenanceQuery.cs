namespace Vemo.Application.Features.Vehicles.Queries.GetMaintenance;

/// <summary>
/// GetMaintenanceQuery
/// </summary>
public class GetMaintenanceQuery : IRequest<object>
{
    /// <summary>
    /// Gets or sets VehicleId
    /// </summary>
    public Guid UserId { get; set; }
}