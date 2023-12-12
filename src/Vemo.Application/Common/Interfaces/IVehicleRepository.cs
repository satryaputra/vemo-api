﻿using Vemo.Domain.Entities.Vehicles;

namespace Vemo.Application.Common.Interfaces;

/// <summary>
/// IVehicleRepository
/// </summary>
public interface IVehicleRepository
{
    /// <summary>
    /// AddVehicleAsync
    /// </summary>
    /// <param name="vehicle"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddVehicleAsync(Vehicle vehicle, CancellationToken cancellationToken);

    /// <summary>
    /// IsVehicleExistsByLicensePlateAsync
    /// </summary>
    /// <param name="licensePlate"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> IsVehicleExistsByLicensePlateAsync(string licensePlate, CancellationToken cancellationToken);
    
    /// <summary>
    /// Pending
    /// </summary>
    /// <returns></returns>
    string Pending();

    /// <summary>
    /// Approve
    /// </summary>
    /// <returns></returns>
    string Approve();
}