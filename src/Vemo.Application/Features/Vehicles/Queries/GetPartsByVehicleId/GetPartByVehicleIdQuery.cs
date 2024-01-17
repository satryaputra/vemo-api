using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Features.Vehicles.Queries.GetPartsByVehicleId;

/// <summary>
/// GetPartByVehicleIdQuery
/// </summary>
public class GetPartByVehicleIdQuery : IRequest<List<Part>>
{
    /// <summary>
    /// Gets or sets VehicleId
    /// </summary>
    public Guid? VehicleId { get; set; }
}