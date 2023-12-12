using AutoMapper;
using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Features.Vehicles.Commands.AddVehicle;

/// <summary>
/// AddVehicleCommandHandler
/// </summary>
internal sealed class AddVehicleCommandHandler : IRequestHandler<AddVehicleCommand, GenericResponseDto>
{
    private readonly IMapper _mapper;
    private readonly IVehicleRepository _vehicleRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="AddVehicleCommandHandler"/> class.
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="vehicleRepository"></param>
    public AddVehicleCommandHandler(IMapper mapper, IVehicleRepository vehicleRepository)
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
    /// <exception cref="BadRequestException"></exception>
    public async Task<GenericResponseDto> Handle(AddVehicleCommand request, CancellationToken cancellationToken)
    {
        if (await _vehicleRepository.IsVehicleExistsByLicensePlateAsync(request.LicensePlate, cancellationToken))
        {
            throw new BadRequestException("Plat nomor sudah terdaftar");
        }
        
        var newVehicle = _mapper.Map<Vehicle>(request);
        newVehicle.Status = _vehicleRepository.Pending();
        await _vehicleRepository.AddVehicleAsync(newVehicle, cancellationToken);

        return new GenericResponseDto("Berhasil menambahkan kendaraan");
    }
}