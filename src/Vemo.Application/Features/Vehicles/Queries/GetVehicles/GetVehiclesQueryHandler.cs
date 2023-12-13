﻿using AutoMapper;
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

    /// <summary>
    /// Initialize a new instance of the <see cref="GetVehiclesQueryHandler"/> class.
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="vehicleRepository"></param>
    public GetVehiclesQueryHandler(IMapper mapper, IVehicleRepository vehicleRepository)
    {
        _mapper = mapper;
        _vehicleRepository = vehicleRepository;
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
            return _mapper.Map<List<VehicleResponseDto>>(vehicles);
        }
        else if (request.UserId is null && request.Status != null)
        {
            var vehicles = await _vehicleRepository.GetVehiclesByStatusAsync(request.Status, cancellationToken);
            return _mapper.Map<List<VehicleResponseDto>>(vehicles);
        }
        else if (request.UserId is not null && !string.IsNullOrEmpty(request.Status))
        {
            throw new Exception("This features is under development");
        }
        else
        {
            var vehicles = await _vehicleRepository.GetAllVehiclesAsync(cancellationToken);
            return _mapper.Map<List<VehicleResponseDto>>(vehicles);
        }
    }
}