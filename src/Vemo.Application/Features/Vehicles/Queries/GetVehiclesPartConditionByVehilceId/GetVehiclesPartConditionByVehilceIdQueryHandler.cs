using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Vehicles.Queries.GetVehiclesPartConditionByVehilceId;

/// <summary>
/// GetVehiclesPartConditionByVehilceIdQueryHandler
/// </summary>
internal sealed class GetVehiclesPartConditionByVehilceIdQueryHandler : IRequestHandler<
    GetVehiclesPartConditionByVehilceIdQuery, List<VehiclePartConditionResponseDto>>
{
    private readonly IVehiclePartRepository _partRepository;
    private readonly IVehiclePartConditionRepository _conditionRepository;

    public GetVehiclesPartConditionByVehilceIdQueryHandler(
        IVehiclePartRepository partRepository,
        IVehiclePartConditionRepository conditionRepository)
    {
        _partRepository = partRepository;
        _conditionRepository = conditionRepository;
    }

    public async Task<List<VehiclePartConditionResponseDto>> Handle(GetVehiclesPartConditionByVehilceIdQuery request,
        CancellationToken cancellationToken)
    {
        var vehiclePartConditions =
            await _conditionRepository.GetVehiclesPartConditionByVehicleIdAsync(request.VehicleId, cancellationToken);
        
        var result = new List<VehiclePartConditionResponseDto>();

        foreach (var vehiclePartCondition in vehiclePartConditions)
        {
            var vehiclePart =
                await _partRepository.GetVehiclePartByIdAsync(vehiclePartCondition.VehiclePartId, cancellationToken);

            int percentage;

            var monthsSinceLastMaintenance =
                (int)((DateTime.Now - vehiclePartCondition.LastMaintenance).TotalDays / 30.44);

            if (monthsSinceLastMaintenance >= vehiclePart.AgeInMonth)
            {
                percentage = 100;
            }
            else
            {
                percentage = 100 * monthsSinceLastMaintenance / vehiclePart.AgeInMonth;
            }
            
            var responseDto = new VehiclePartConditionResponseDto
            {
                VehiclePartConditionId = vehiclePartCondition.Id,
                VehiclePartId = vehiclePart.Id,
                VehiclePartName = vehiclePart.Name,
                Condition = percentage
            };

            result.Add(responseDto);
        }
        
        return result;
    }
}