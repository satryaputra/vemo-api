using AutoMapper;
using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Application.Common.Utils;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Features.Vehicles.Commands.AddVehicle;

/// <summary>
/// AddVehicleCommandHandler
/// </summary>
internal sealed class AddVehicleCommandHandler : IRequestHandler<AddVehicleCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IPartRepository _partRepository;
    private readonly IConditionPartRepository _conditionRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="AddVehicleCommandHandler"/> class.
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="vehicleRepository"></param>
    /// <param name="partRepository"></param>
    public AddVehicleCommandHandler(
        IMapper mapper, 
        IVehicleRepository vehicleRepository, 
        IPartRepository partRepository, IConditionPartRepository conditionRepository)
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
    /// <exception cref="BadRequestException"></exception>
    public async Task<Guid> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
    {
        if (DateTimeUtcConverter.FromIsoString(request.PurchasingDate) > DateTime.Now)
        {
            throw new BadRequestException("Pembelian tanggal kendaraan tidak valid");
        }

        if (request.LastMaintenance < 0)
        {
            throw new BadRequestException("Tanggal terakhir perawatan kendaraan tidak valid");
        }
        
        if (await _vehicleRepository.IsVehicleExistsByLicensePlateAsync(request.LicensePlate, cancellationToken))
        {
            throw new BadRequestException("Plat nomor sudah terdaftar");
        }
        
        // Add new vehicle with status pending
        var newVehicle = _mapper.Map<Vehicle>(request);
        newVehicle.Status = _vehicleRepository.Pending();
        await _vehicleRepository.AddVehicleAsync(newVehicle, cancellationToken);

        var parts = await _partRepository.GetPartsByVehicleType(request.VehicleType, cancellationToken);
        
        // Generate vehicle condition
        foreach (var part in parts)
        {
            var newConditionPart = new ConditionPart
            {
                LastMaintenance = DateTimeUtcConverter.FromInt(-request.LastMaintenance),
                PartId = part.Id,
                VehicleId = newVehicle.Id
            };
            
            await _conditionRepository.AddConditionPartAsync(newConditionPart, cancellationToken);
        }

        return newVehicle.Id;
    }
}