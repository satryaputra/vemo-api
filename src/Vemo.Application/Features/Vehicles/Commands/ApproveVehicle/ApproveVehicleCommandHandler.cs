using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Vehicles.Commands.ApproveVehicle;

/// <summary>
/// ApproveVehicleCommandHandler
/// </summary>
internal sealed class ApproveVehicleCommandHandler : IRequestHandler<ApproveVehicleCommand, GenericResponseDto>
{
    private readonly IVehicleRepository _vehicleRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="ApproveVehicleCommandHandler"/> class.
    /// </summary>
    /// <param name="vehicleRepository"></param>
    public ApproveVehicleCommandHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GenericResponseDto> Handle(ApproveVehicleCommand request, CancellationToken cancellationToken)
    {
        await _vehicleRepository.ApproveVehicleAsync(request.VehicleId, cancellationToken);
        return new GenericResponseDto("Kendaraan telah disetujui");
    }
}