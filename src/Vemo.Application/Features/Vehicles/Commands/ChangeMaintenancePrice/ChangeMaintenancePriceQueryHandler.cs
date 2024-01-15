using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Vehicles.Commands.ChangeMaintenancePrice;

/// <summary>
/// ChangeMaintenancePriceQueryHandler
/// </summary>
internal sealed class ChangeMaintenancePriceQueryHandler : IRequestHandler<ChangeMaintenancePriceQuery, object>
{
    private readonly IMaintenancePartRepository _maintenancePartRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="ChangeMaintenancePriceQueryHandler"/> class.
    /// </summary>
    /// <param name="maintenancePartRepository"></param>
    public ChangeMaintenancePriceQueryHandler(IMaintenancePartRepository maintenancePartRepository)
    {
        _maintenancePartRepository = maintenancePartRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<object> Handle(ChangeMaintenancePriceQuery request, CancellationToken cancellationToken)
    {
        var maintenancePart =
            await _maintenancePartRepository.GetMaintenancePartById(request.MaintenancePartId, cancellationToken);

        await _maintenancePartRepository.UpdateMaintenancePriceAsync(maintenancePart, request.NewPrice,
            cancellationToken);

        return new GenericResponseDto("Berhasil mengubah harga service");
    }
}