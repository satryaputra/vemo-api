using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Features.Vehicles.Queries.GetPartsByVehicleId;

/// <summary>
/// GetPartByVehicleIdQueryHandler
/// </summary>
internal sealed class GetPartByVehicleIdQueryHandler : IRequestHandler<GetPartByVehicleIdQuery, List<Part>>
{
    private readonly IPartRepository _partRepository;
    private readonly IConditionPartRepository _conditionPartRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="GetPartByVehicleIdQueryHandler"/> class.
    /// </summary>
    /// <param name="partRepository"></param>
    /// <param name="conditionPartRepository"></param>
    public GetPartByVehicleIdQueryHandler(
        IPartRepository partRepository, 
        IConditionPartRepository conditionPartRepository)
    {
        _partRepository = partRepository;
        _conditionPartRepository = conditionPartRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<Part>> Handle(GetPartByVehicleIdQuery request, CancellationToken cancellationToken)
    {
        var conditionParts = await _conditionPartRepository.GetConditionPartsByVehicleIdAsync(request.VehicleId,
            cancellationToken);
        var parts = new List<Part>();
        foreach (var conditionPart in conditionParts)
        {
            var part = await _partRepository.GetPartByIdAsync(conditionPart.PartId, cancellationToken);
            parts.Add(part);
        }

        return parts;
    }
}