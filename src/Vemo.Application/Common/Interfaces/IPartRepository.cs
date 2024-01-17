using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Common.Interfaces;

/// <summary>
/// IPartRepository
/// </summary>
public interface IPartRepository
{
    /// <summary>
    /// AddPartAsync
    /// </summary>
    /// <param name="part"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddPartAsync(Part part, CancellationToken cancellationToken);

    /// <summary>
    /// UpdatePartAsync
    /// </summary>
    /// <param name="part"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdatePartAsync(Part part, CancellationToken cancellationToken);

    /// <summary>
    /// DeletePartAsync
    /// </summary>
    /// <param name="part"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeletePartAsync(Part part, CancellationToken cancellationToken);

    /// <summary>
    /// GetAllPartsAsync
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<Part>> GetAllPartsAsync(CancellationToken cancellationToken);

    /// <summary>
    /// GetPartByIdAsync
    /// </summary>
    /// <param name="partId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Part> GetPartByIdAsync(Guid partId, CancellationToken cancellationToken);

    /// <summary>
    /// GetPartsByVehicleType
    /// </summary>
    /// <param name="vehicleType"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<Part>> GetPartsByVehicleType(string vehicleType, CancellationToken cancellationToken);
}