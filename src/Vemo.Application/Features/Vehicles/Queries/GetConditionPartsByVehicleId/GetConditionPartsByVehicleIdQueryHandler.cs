using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Vehicles.Queries.GetConditionPartsByVehicleId;

/// <summary>
/// GetConditionPartsByVehicleIdQueryHandler
/// </summary>
internal sealed class GetConditionPartsByVehicleIdQueryHandler : IRequestHandler<
    GetConditionPartsByVehicleIdQuery, List<ConditionPartResponseDto>>
{
    private readonly IPartRepository _partRepository;
    private readonly IConditionPartRepository _conditionPartRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="GetConditionPartsByVehicleIdQueryHandler"/> class
    /// </summary>
    /// <param name="conditionPartRepository"></param>
    /// <param name="partRepository"></param>
    public GetConditionPartsByVehicleIdQueryHandler(
        IConditionPartRepository conditionPartRepository, 
        IPartRepository partRepository)
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
    public async Task<List<ConditionPartResponseDto>> Handle(GetConditionPartsByVehicleIdQuery request,
        CancellationToken cancellationToken)
    {
        var conditionPartVehicles = await _conditionPartRepository.GetConditionPartsByVehicleIdAsync(request.VehicleId, cancellationToken);
        
        var result = new List<ConditionPartResponseDto>();

        foreach (var conditionPartVehicle in conditionPartVehicles)
        {
            var part = await _partRepository.GetPartByIdAsync(conditionPartVehicle.PartId, cancellationToken);

            int percentage;

            var monthsSinceLastMaintenance =
                (int)((DateTime.Now - conditionPartVehicle.LastMaintenance).TotalDays / 30.44);

            if (monthsSinceLastMaintenance >= part.AgeInMonth)
            {
                percentage = 100;
            }
            else
            {
                percentage = 100 * monthsSinceLastMaintenance / part.AgeInMonth;
            }
            
            var responseDto = new ConditionPartResponseDto
            {
                ConditionPartId = conditionPartVehicle.Id,
                PartId = part.Id,
                PartName = part.Name,
                Condition = percentage
            };

            result.Add(responseDto);
        }
        
        return result;
    }
}