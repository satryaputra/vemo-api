using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Vehicles.Commands.UpdatePart;

public class UpdatePartCommandHandler : IRequestHandler<UpdatePartCommand, object>
{
    private readonly IPartRepository _partRepository;

    public UpdatePartCommandHandler(IPartRepository partRepository)
    {
        _partRepository = partRepository;
    }

    public async Task<object> Handle(UpdatePartCommand request, CancellationToken cancellationToken)
    {
        var part = await _partRepository.GetPartByIdAsync(request.PartId, cancellationToken);

        part.Name = request.Name ?? part.Name;
        part.AgeInMonth = request.AgeInMonth ?? part.AgeInMonth;
        part.MaintenancePrice = request.MaintenancePrice ?? part.MaintenancePrice;
        part.MaintenanceServicePrice = request.MaintenanceServicePrice ?? part.MaintenanceServicePrice;
        part.VehicleType = request.VehicleType ?? part.VehicleType;
        part.UpdatedAt = DateTime.UtcNow;

        await _partRepository.UpdatePartAsync(part, cancellationToken);

        return new GenericResponseDto("Berhasil update part");
    }
}