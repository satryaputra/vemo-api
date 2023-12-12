using AutoMapper;
using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Vehicles.Queries.GetVehicleById;

/// <summary>
/// GetVehicleByIdQueryHandler
/// </summary>
internal sealed class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, VehicleResponseDto>
{
    private readonly IMapper _mapper;
    private readonly IVehicleRepository _vehicleRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="GetVehicleByIdQueryHandler"/> class.
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="vehicleRepository"></param>
    public GetVehicleByIdQueryHandler(IMapper mapper, IVehicleRepository vehicleRepository)
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
    public async Task<VehicleResponseDto> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetVehicleByIdAsync(request.VehicleId, cancellationToken);
        return _mapper.Map<VehicleResponseDto>(vehicle);
    }
}