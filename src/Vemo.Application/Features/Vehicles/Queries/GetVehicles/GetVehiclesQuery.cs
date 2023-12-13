namespace Vemo.Application.Features.Vehicles.Queries.GetVehicles;

/// <summary>
/// GetVehiclesQuery
/// </summary>
public class GetVehiclesQuery : IRequest<List<VehicleResponseExcludeUserIdDto>>
{
    /// <summary>
    /// Gets or sets UserId
    /// </summary>
    public Guid? UserId { get; set; }

    public string? Status { get; set; }
}