namespace Vemo.Application.Features.Vehicles.Queries.GetVehicleById;

/// <summary>
/// GetVehicleByIdQuery
/// </summary>
public class GetVehicleByIdQuery : IRequest<VehicleResponseDto>
{
    /// <summary>
    /// Gets or sets VehicleId
    /// </summary>
    public Guid VehicleId { get; set; }
}