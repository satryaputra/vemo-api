using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Features.Vehicles.Queries.GetPartById;

/// <summary>
/// GetPartByIdQueryHandler
/// </summary>
internal sealed class GetPartByIdQueryHandler : IRequestHandler<GetPartByIdQuery, Part>
{
    private readonly IPartRepository _partRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="GetPartByIdQueryHandler"/> class.
    /// </summary>
    /// <param name="partRepository"></param>
    public GetPartByIdQueryHandler(IPartRepository partRepository)
    {
        _partRepository = partRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Part> Handle(GetPartByIdQuery request, CancellationToken cancellationToken)
    {
        return await _partRepository.GetPartByIdAsync(request.PartId, cancellationToken);
    }
}