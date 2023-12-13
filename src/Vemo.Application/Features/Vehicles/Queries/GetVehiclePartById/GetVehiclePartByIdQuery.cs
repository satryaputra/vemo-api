using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Features.Vehicles.Queries.GetVehiclePartById;

/// <summary>
/// GetVehiclePartByIdQuery
/// </summary>
public class GetVehiclePartByIdQuery : IRequest<VehiclePart>
{
    /// <summary>
    /// VehiclePartId
    /// </summary>
    public Guid VehiclePartId { get; set; }
}