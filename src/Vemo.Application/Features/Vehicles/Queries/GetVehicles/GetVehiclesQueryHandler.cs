using AutoMapper;
using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Vehicles.Queries.GetVehicles;

/// <summary>
/// GetVehiclesQueryHandler
/// </summary>
internal sealed class GetVehiclesQueryHandler : IRequestHandler<GetVehiclesQuery, List<VehicleResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IVehiclePartRepository _partRepository;
    private readonly IVehiclePartConditionRepository _conditionRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="GetVehiclesQueryHandler"/> class.
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="vehicleRepository"></param>
    /// <param name="partRepository"></param>
    /// <param name="conditionRepository"></param>
    public GetVehiclesQueryHandler(
        IMapper mapper,
        IVehicleRepository vehicleRepository,
        IVehiclePartRepository partRepository,
        IVehiclePartConditionRepository conditionRepository)
    {
        _mapper = mapper;
        _vehicleRepository = vehicleRepository;
        _partRepository = partRepository;
        _conditionRepository = conditionRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<VehicleResponseDto>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
    {
        if (request.UserId is not null && string.IsNullOrEmpty(request.Status))
        {
            var vehicles = await _vehicleRepository.GetVehiclesByUserIdAsync(request.UserId, cancellationToken);
            var vehiclesMapped = _mapper.Map<List<VehicleResponseDto>>(vehicles);
            
            foreach (var vehicle in vehiclesMapped)
            {
                var vehiclePartConditions = await GetVehiclePartConditionByVehicleIdAsync(vehicle.VehicleId, cancellationToken);
                var vehiclePartConditionsAverage = vehiclePartConditions.Average(x => x.Condition);
                vehicle.Condition = vehiclePartConditionsAverage;
            }

            return vehiclesMapped;
        }
        else if (request.UserId is null && request.Status != null)
        {
            var vehicles = await _vehicleRepository.GetVehiclesByStatusAsync(request.Status, cancellationToken);
            var vehiclesMapped = _mapper.Map<List<VehicleResponseDto>>(vehicles);
            
            foreach (var vehicle in vehiclesMapped)
            {
                var vehiclePartConditions = await GetVehiclePartConditionByVehicleIdAsync(vehicle.VehicleId, cancellationToken);
                var vehiclePartConditionsAverage = vehiclePartConditions.Average(x => x.Condition);
                vehicle.Condition = vehiclePartConditionsAverage;
            }

            return vehiclesMapped;
        }
        else if (request.UserId is not null && !string.IsNullOrEmpty(request.Status))
        {
            throw new Exception("This features is under development");
        }
        else
        {
            var vehicles = await _vehicleRepository.GetAllVehiclesAsync(cancellationToken);
            var vehiclesMapped = _mapper.Map<List<VehicleResponseDto>>(vehicles);
            
            foreach (var vehicle in vehiclesMapped)
            {
                var vehiclePartConditions = await GetVehiclePartConditionByVehicleIdAsync(vehicle.VehicleId, cancellationToken);
                var vehiclePartConditionsAverage = vehiclePartConditions.Average(x => x.Condition);
                vehicle.Condition = vehiclePartConditionsAverage;
            }

            return vehiclesMapped;
        }
    }

    private async Task<List<VehiclePartConditionResponseDto>> GetVehiclePartConditionByVehicleIdAsync(Guid vehicleId,
        CancellationToken cancellationToken)
    {
        var vehiclePartConditions =
            await _conditionRepository.GetVehiclesPartConditionByVehicleIdAsync(vehicleId, cancellationToken);

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