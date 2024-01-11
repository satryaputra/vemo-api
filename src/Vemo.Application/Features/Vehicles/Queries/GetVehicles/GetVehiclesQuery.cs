namespace Vemo.Application.Features.Vehicles.Queries.GetVehicles;

/// <summary>
/// GetVehiclesQuery
/// </summary>
public class GetVehiclesQuery : IRequest<List<VehicleResponseDto>>
{
    /// <summary>
    /// Gets or sets UserId
    /// </summary>
    public Guid? UserId { get; set; }

    /// <summary>
    /// Gets or sets UserId Status
    /// </summary>
    public string? Status { get; set; }

    /// <summary>
    /// Gets or sets UserId Status
    /// </summary>
    public string? MaintenanceStatus { get; set; }
}