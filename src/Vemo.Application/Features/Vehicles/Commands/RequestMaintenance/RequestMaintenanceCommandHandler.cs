using AutoMapper;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Features.Vehicles.Commands.RequestMaintenance;

/// <summary>
/// RequestMaintenanceCommandHandler
/// </summary>
internal sealed class RequestMaintenanceCommandHandler : IRequestHandler<RequestMaintenanceCommand, GenericResponseDto>
{
    private readonly IMapper _mapper;
    private readonly IPartRepository _partRepository;
    private readonly IMaintenanceVehicleRepository _maintenanceVehicleRepository;
    private readonly IMaintenancePartRepository _maintenancePartRepository;

    public RequestMaintenanceCommandHandler(
        IMapper mapper,
        IPartRepository partRepository,
        IMaintenanceVehicleRepository maintenanceVehicleRepository, 
        IMaintenancePartRepository maintenancePartRepository)
    {
        _mapper = mapper;
        _partRepository = partRepository;
        _maintenanceVehicleRepository = maintenanceVehicleRepository;
        _maintenancePartRepository = maintenancePartRepository;
    }

    public async Task<GenericResponseDto> Handle(RequestMaintenanceCommand request, CancellationToken cancellationToken)
    {
        var newMaintenanceVehicle = _mapper.Map<MaintenanceVehicle>(request);
        newMaintenanceVehicle.Status = _maintenanceVehicleRepository.RequestMaintenance();
        await _maintenanceVehicleRepository.AddMaintenanceVehicleAsync(newMaintenanceVehicle, cancellationToken);

        foreach (var partId in request.ListPartId)
        {
            var part = await _partRepository.GetPartByIdAsync(partId, cancellationToken);

            var newMaintenancePart = new MaintenancePart
            {
                MaintenanceVehicleId = newMaintenanceVehicle.Id,
                PartId = partId,
                MaintenanceFinalPrice = part.MaintenancePrice,
                MaintenanceServiceFinalPrice = part.MaintenanceServicePrice
            };

            await _maintenancePartRepository.AddMaintenancePartAsync(newMaintenancePart, cancellationToken);
        }

        return new GenericResponseDto("Berhasil mengirim permintaan perawatan");
    }
}