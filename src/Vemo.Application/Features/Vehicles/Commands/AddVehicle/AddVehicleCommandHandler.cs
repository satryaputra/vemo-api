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
    private readonly IVehiclePartRepository _partRepository;
    private readonly IVehiclePartConditionRepository _conditionRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="AddVehicleCommandHandler"/> class.
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="vehicleRepository"></param>
    /// <param name="partRepository"></param>
    public AddVehicleCommandHandler(
        IMapper mapper, 
        IVehicleRepository vehicleRepository, 
        IVehiclePartRepository partRepository, IVehiclePartConditionRepository conditionRepository)
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
        if (DateTimeConverter.ToDateTimeUtc(request.PurchasingDate) > DateTime.Now)
        {
            throw new BadRequestException("Pembelian tanggal kendaraan tidak valid");
        }
        
        if (await _vehicleRepository.IsVehicleExistsByLicensePlateAsync(request.LicensePlate, cancellationToken))
        {
            throw new BadRequestException("Plat nomor sudah terdaftar");
        }
        
        var newVehicle = _mapper.Map<Vehicle>(request);
        newVehicle.Status = _vehicleRepository.Pending();
        await _vehicleRepository.AddVehicleAsync(newVehicle, cancellationToken);

        var vehicleParts = await _partRepository.GetVehiclePartsByVehicleType(request.VehicleType, cancellationToken);
        
        var conditionTasks = vehicleParts.Select(vehiclePart =>
        {
            var newVehiclePartCondition = new VehiclePartCondition(
                DateTime.UtcNow.AddMonths(-request.LastMaintenance),
                DateTime.UtcNow.AddMonths(vehiclePart.AgeInMonth),
                newVehicle.Id,
                vehiclePart.Id);

            return _conditionRepository.AddVehiclePartConditionAsync(newVehiclePartCondition, cancellationToken);
        });
        
        await Task.WhenAll(conditionTasks);

        return newVehicle.Id;
    }
}