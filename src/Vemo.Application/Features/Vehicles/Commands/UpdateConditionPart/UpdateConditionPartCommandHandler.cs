using Vemo.Application.Common.Interfaces;
using Vemo.Application.Common.Utils;

namespace Vemo.Application.Features.Vehicles.Commands.UpdateConditionPart;

/// <summary>
/// UpdateConditionPartCommandHandler
/// </summary>
internal sealed class UpdateConditionPartCommandHandler : IRequestHandler<UpdateConditionPartCommand, object>
{
    private readonly IConditionPartRepository _conditionPartRepository;

    public UpdateConditionPartCommandHandler(IConditionPartRepository conditionPartRepository)
    {
        _conditionPartRepository = conditionPartRepository;
    }

    public async Task<object> Handle(UpdateConditionPartCommand request, CancellationToken cancellationToken)
    {
        await _conditionPartRepository.UpdateLastMaintenanceAsync(request.ConditionPartId,
            DateTimeUtcConverter.FromIsoString(request.NewLastMaintenanceDate), cancellationToken);

        return new GenericResponseDto("Berhasil udpate kondisi part");
    }
}