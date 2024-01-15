namespace Vemo.Application.Features.Vehicles.Queries.GetMaintenanceById;

/// <summary>
/// GetMaintenanceByIdQuery
/// </summary>
public class GetMaintenanceByIdQuery : IRequest<object>
{
    /// <summary>
    /// Gets or sets MaintenanceIdQuery
    /// </summary>
    public Guid MaintenanceId { get; set; }
}