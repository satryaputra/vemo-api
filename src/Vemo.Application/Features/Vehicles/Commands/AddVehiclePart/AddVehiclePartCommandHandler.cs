using AutoMapper;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Features.Vehicles.Commands.AddVehiclePart;

/// <summary>
/// AddVehiclePartCommandHandler
/// </summary>
internal sealed class AddVehiclePartCommandHandler : IRequestHandler<AddVehiclePartCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IVehiclePartRepository _partRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="AddVehiclePartCommandHandler"/> class.
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="partRepository"></param>
    public AddVehiclePartCommandHandler(IMapper mapper, IVehiclePartRepository partRepository)
    {
        _mapper = mapper;
        _partRepository = partRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Guid> Handle(AddVehiclePartCommand request, CancellationToken cancellationToken)
    {
        var vehiclePart = _mapper.Map<VehiclePart>(request);
        await _partRepository.AddVehiclePartAsync(vehiclePart, cancellationToken);
        return vehiclePart.Id;
    }
}