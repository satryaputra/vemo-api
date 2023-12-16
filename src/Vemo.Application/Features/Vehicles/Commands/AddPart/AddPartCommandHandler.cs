using AutoMapper;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Features.Vehicles.Commands.AddPart;

/// <summary>
/// AddVehiclePartCommandHandler
/// </summary>
internal sealed class AddPartVehicleCommandHandler : IRequestHandler<AddPartVehicleCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IPartRepository _partRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="AddPartVehicleCommandHandler"/> class.
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="partRepository"></param>
    public AddPartVehicleCommandHandler(
        IMapper mapper, 
        IPartRepository partRepository)
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
    public async Task<Guid> Handle(AddPartVehicleCommand request, CancellationToken cancellationToken)
    {
        var part = _mapper.Map<Part>(request);
        await _partRepository.AddPartAsync(part, cancellationToken);
        return part.Id;
    }
}