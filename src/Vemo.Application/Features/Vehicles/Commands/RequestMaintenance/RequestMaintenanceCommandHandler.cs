using AutoMapper;
using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Features.Vehicles.Commands.RequestMaintenance;

/// <summary>
/// RequestMaintenanceCommandHandler
/// </summary>
internal sealed class RequestMaintenanceCommandHandler : IRequestHandler<RequestMaintenanceCommand, GenericResponseDto>
{
    private readonly IMapper _mapper;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IPartRepository _partRepository;
    private readonly IMaintenanceVehicleRepository _maintenanceVehicleRepository;
    private readonly IMaintenancePartRepository _maintenancePartRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="RequestMaintenanceCommandHandler" /> class.
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="vehicleRepository"></param>
    /// <param name="partRepository"></param>
    /// <param name="maintenanceVehicleRepository"></param>
    /// <param name="maintenancePartRepository"></param>
    public RequestMaintenanceCommandHandler(
        IMapper mapper,
        IVehicleRepository vehicleRepository,
        IPartRepository partRepository,
        IMaintenanceVehicleRepository maintenanceVehicleRepository, 
        IMaintenancePartRepository maintenancePartRepository)
    {
        _mapper = mapper;
        _vehicleRepository = vehicleRepository;
        _partRepository = partRepository;
        _maintenanceVehicleRepository = maintenanceVehicleRepository;
        _maintenancePartRepository = maintenancePartRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GenericResponseDto> Handle(RequestMaintenanceCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetVehicleByIdAsync(request.VehicleId, cancellationToken);

        if (vehicle.Status.Equals(_vehicleRepository.Pending()))
        {
            throw new BadRequestException("Kendaraan masih dalam status pending");
        }
        
        var newMaintenanceVehicle = _mapper.Map<MaintenanceVehicle>(request);
        newMaintenanceVehicle.Status = _maintenanceVehicleRepository.RequestMaintenance();
        await _maintenanceVehicleRepository.AddMaintenanceVehicleAsync(newMaintenanceVehicle, cancellationToken);
        
        // Update status of vehicle
        await _vehicleRepository.UpdateStatusVehicleAsync(
            request.VehicleId,
            _maintenanceVehicleRepository.RequestMaintenance(),
            cancellationToken);

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