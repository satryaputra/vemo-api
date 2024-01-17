using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Features.Vehicles.Queries.GetAllParts;

/// <summary>
/// GetAllPartsQueryHandler
/// </summary>
internal sealed class GetAllPartsQueryHandler : IRequestHandler<GetAllPartsQuery, List<Part>>
{
    private readonly IPartRepository _partRepository;

    public GetAllPartsQueryHandler(IPartRepository partRepository)
    {
        _partRepository = partRepository;
    }

    public async Task<List<Part>> Handle(GetAllPartsQuery request, CancellationToken cancellationToken)
    {
        return await _partRepository.GetAllPartsAsync(cancellationToken);
    }
}