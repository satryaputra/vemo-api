using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Features.Vehicles.Queries.GetPartById;

/// <summary>
/// GetPartByIdQuery
/// </summary>
public class GetPartByIdQuery : IRequest<Part>
{
    /// <summary>
    /// Gets or sets PartId
    /// </summary>
    public Guid PartId { get; set; }
}