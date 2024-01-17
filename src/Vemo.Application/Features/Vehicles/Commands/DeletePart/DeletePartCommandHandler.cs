using Vemo.Application.Common.Interfaces;

namespace Vemo.Application.Features.Vehicles.Commands.DeletePart;

internal sealed class DeletePartCommandHandler : IRequestHandler<DeletePartCommand, object>
{
    private readonly IPartRepository _partRepository;

    public DeletePartCommandHandler(IPartRepository partRepository)
    {
        _partRepository = partRepository;
    }

    public async Task<object> Handle(DeletePartCommand request, CancellationToken cancellationToken)
    {
        await _partRepository.DeletePartAsync(await _partRepository.GetPartByIdAsync(request.PartId, cancellationToken),
            cancellationToken);

        return new GenericResponseDto("Berhasil menghapus kendaraan");
    }
}