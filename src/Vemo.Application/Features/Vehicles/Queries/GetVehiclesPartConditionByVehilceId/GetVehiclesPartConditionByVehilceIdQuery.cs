namespace Vemo.Application.Features.Vehicles.Queries.GetVehiclesPartConditionByVehilceId;

/// <summary>
/// GetVehiclesPartConditionByVehilceIdQuery
/// </summary>
public class GetVehiclesPartConditionByVehilceIdQuery : IRequest<List<VehiclePartConditionResponseDto>>
{
    /// <summary>
    /// Gets or sets VehicleId
    /// </summary>
    public Guid VehicleId { get; set; }
}