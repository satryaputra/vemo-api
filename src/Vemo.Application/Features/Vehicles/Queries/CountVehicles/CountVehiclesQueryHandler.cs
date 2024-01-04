using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Vehicles.Queries.CountVehicles;

/// <summary>
/// CountVehiclesQueryHandler
/// </summary>
public class CountVehiclesQueryHandler : IRequestHandler<CountVehiclesQuery, object>
{
    private readonly IVehicleRepository _vehicleRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="CountVehiclesQueryHandler"/> class.
    /// </summary>
    /// <param name="vehicleRepository"></param>
    public CountVehiclesQueryHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<object> Handle(CountVehiclesQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await _vehicleRepository.GetAllVehiclesAsync(cancellationToken);
        return new
        {
            vehicles = vehicles.Count(v => v.Status != "pending"),
            matic = vehicles.Count(v => v.Status != "pending" && v.Type == "matic"),
            manual = vehicles.Count(v => v.Status != "pending" && v.Type == "manual"),
            pending = vehicles.Count(v => v.Status == "pending"),
            requested = vehicles.Count(v => v.Status == "requested"),
        };
    }
}