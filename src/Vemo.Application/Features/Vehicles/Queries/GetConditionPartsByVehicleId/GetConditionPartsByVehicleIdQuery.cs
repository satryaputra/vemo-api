namespace Vemo.Application.Features.Vehicles.Queries.GetConditionPartsByVehicleId;

/// <summary>
/// GetConditionPartsByVehicleIdQuery
/// </summary>
public class GetConditionPartsByVehicleIdQuery : IRequest<List<ConditionPartResponseDto>>
{
    /// <summary>
    /// Gets or sets VehicleId
    /// </summary>
    public Guid VehicleId { get; set; }
}