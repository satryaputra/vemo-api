﻿using Vemo.Domain.Entities.Vehicles;

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