using AutoMapper;
using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Vehicles.Queries.GetVehicles;

/// <summary>
/// GetVehiclesQueryHandler
/// </summary>
internal sealed class GetVehiclesQueryHandler : IRequestHandler<GetVehiclesQuery, List<VehicleResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IPartRepository _partRepository;
    private readonly IConditionPartRepository _conditionRepository;

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
        IPartRepository partRepository,
        IConditionPartRepository conditionRepository)
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
        // Get vehicle by user id
        if (request.UserId is not null && string.IsNullOrEmpty(request.Status) &&
            string.IsNullOrEmpty(request.MaintenanceStatus))
        {
            var vehicles = await _vehicleRepository.GetVehiclesByUserIdAsync(request.UserId, cancellationToken);
            var vehiclesMapped = _mapper.Map<List<VehicleResponseDto>>(vehicles);

            // fill average condition for per vehicle
            foreach (var vehicle in vehiclesMapped)
            {
                var vehiclePartConditions =
                    await GetPartConditionByVehicleIdAsync(vehicle.VehicleId, cancellationToken);
                var vehiclePartConditionsAverage = vehiclePartConditions.Average(x => x.Condition);
                vehicle.Condition = vehiclePartConditionsAverage;
            }

            return vehiclesMapped;
        }
        // Get vehicle by vehicle status
        else if (request.UserId is null && request.Status is not null &&
                 string.IsNullOrEmpty(request.MaintenanceStatus))
        {
            var vehicles = await _vehicleRepository.GetVehiclesByStatusAsync(request.Status, cancellationToken);
            var vehiclesMapped = _mapper.Map<List<VehicleResponseDto>>(vehicles);

            foreach (var vehicle in vehiclesMapped)
            {
                var vehiclePartConditions =
                    await GetPartConditionByVehicleIdAsync(vehicle.VehicleId, cancellationToken);
                var vehiclePartConditionsAverage = vehiclePartConditions.Average(x => x.Condition);
                vehicle.Condition = vehiclePartConditionsAverage;
            }

            return vehiclesMapped;
        }
        // Get vehicle by maintenance status
        else if (request.UserId is null && request.Status is null && request.MaintenanceStatus is not null)
        {
            var vehicles =
                await _vehicleRepository.GetVehiclesByMaintenanceStatusAsync(request.MaintenanceStatus,
                    cancellationToken);
            var vehiclesMapped = _mapper.Map<List<VehicleResponseDto>>(vehicles);

            foreach (var vehicle in vehiclesMapped)
            {
                var vehiclePartConditions =
                    await GetPartConditionByVehicleIdAsync(vehicle.VehicleId, cancellationToken);
                var vehiclePartConditionsAverage = vehiclePartConditions.Average(x => x.Condition);
                vehicle.Condition = vehiclePartConditionsAverage;
            }

            return vehiclesMapped;
        }
        else if (request.UserId is not null && !string.IsNullOrEmpty(request.Status))
        {
            throw new NotFoundException("This features is under development");
        }
        else
        {
            var vehicles = await _vehicleRepository.GetAllVehiclesAsync(cancellationToken);
            var vehiclesMapped = _mapper.Map<List<VehicleResponseDto>>(vehicles);

            foreach (var vehicle in vehiclesMapped)
            {
                var vehiclePartConditions =
                    await GetPartConditionByVehicleIdAsync(vehicle.VehicleId, cancellationToken);
                var vehiclePartConditionsAverage = vehiclePartConditions.Average(x => x.Condition);
                vehicle.Condition = vehiclePartConditionsAverage;
            }

            return vehiclesMapped;
        }
    }

    private async Task<List<ConditionPartResponseDto>> GetPartConditionByVehicleIdAsync(Guid vehicleId,
        CancellationToken cancellationToken)
    {
        var conditionParts =
            await _conditionRepository.GetConditionPartsByVehicleIdAsync(vehicleId, cancellationToken);

        var result = new List<ConditionPartResponseDto>();

        foreach (var conditionPart in conditionParts)
        {
            int percentage;

            var part = await _partRepository.GetPartByIdAsync(conditionPart.PartId, cancellationToken);
            var monthsSinceLastMaintenance = (int)((DateTime.Now - conditionPart.LastMaintenance).TotalDays / 30.44);

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
                ConditionPartId = conditionPart.Id,
                PartId = part.Id,
                PartName = part.Name,
                Condition = percentage
            };

            result.Add(responseDto);
        }

        return result;
    }
}