using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Features.Vehicles.Queries.GetVehiclePartById;

internal sealed class GetVehiclePartByIdQueryHandler : IRequestHandler<GetVehiclePartByIdQuery, VehiclePart>
{
    private readonly IVehiclePartRepository _partRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="GetVehiclePartByIdQueryHandler"/> class.
    /// </summary>
    /// <param name="partRepository"></param>
    public GetVehiclePartByIdQueryHandler(IVehiclePartRepository partRepository)
    {
        _partRepository = partRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<VehiclePart> Handle(GetVehiclePartByIdQuery request, CancellationToken cancellationToken)
    {
        return await _partRepository.GetVehiclePartByIdAsync(request.VehiclePartId, cancellationToken);
    }
}