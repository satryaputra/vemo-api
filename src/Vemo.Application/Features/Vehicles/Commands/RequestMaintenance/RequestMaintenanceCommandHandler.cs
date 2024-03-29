﻿using AutoMapper;
using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Domain.Entities.Notifications;
using Vemo.Domain.Entities.Vehicles;
using System.Text;

namespace Vemo.Application.Features.Vehicles.Commands.RequestMaintenance;

/// <summary>
/// RequestMaintenanceCommandHandler
/// </summary>
internal sealed class RequestMaintenanceCommandHandler : IRequestHandler<RequestMaintenanceCommand, GenericResponseDto>
{
    private readonly IMapper _mapper;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IPartRepository _partRepository;
    private readonly IMaintenanceVehicleRepository _maintenanceVehicleRepository;
    private readonly IMaintenancePartRepository _maintenancePartRepository;
    private readonly INotificationRepository _notificationRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="RequestMaintenanceCommandHandler" /> class.
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="vehicleRepository"></param>
    /// <param name="partRepository"></param>
    /// <param name="maintenanceVehicleRepository"></param>
    /// <param name="maintenancePartRepository"></param>
    /// <param name="notificationRepository"></param>
    public RequestMaintenanceCommandHandler(
        IMapper mapper,
        IVehicleRepository vehicleRepository,
        IPartRepository partRepository,
        IMaintenanceVehicleRepository maintenanceVehicleRepository,
        IMaintenancePartRepository maintenancePartRepository,
        INotificationRepository notificationRepository)
    {
        _mapper = mapper;
        _vehicleRepository = vehicleRepository;
        _partRepository = partRepository;
        _maintenanceVehicleRepository = maintenanceVehicleRepository;
        _maintenancePartRepository = maintenancePartRepository;
        _notificationRepository = notificationRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GenericResponseDto> Handle(RequestMaintenanceCommand request, CancellationToken cancellationToken)
    {
        // get
        var vehicle = await _vehicleRepository.GetVehicleByIdAsync(request.VehicleId, cancellationToken);

        var requestMaintenanceVehicles =
            await _maintenanceVehicleRepository.GetRequestByVehicleIdAsync(vehicle.Id, cancellationToken);

        if (requestMaintenanceVehicles is null)
        {
            // Create new maintenance vehicle
            var newMaintenanceVehicle = _mapper.Map<MaintenanceVehicle>(request);
            newMaintenanceVehicle.Ticket = GenerateTicket(8);
            newMaintenanceVehicle.Status = _maintenanceVehicleRepository.RequestMaintenance();
            await _maintenanceVehicleRepository.AddMaintenanceVehicleAsync(newMaintenanceVehicle, cancellationToken);

            // Create new maintenance parts
            foreach (var partId in request.ListPartId)
            {
                var part = await _partRepository.GetPartByIdAsync(partId, cancellationToken);

                var newMaintenancePart = new MaintenancePart
                {
                    MaintenanceVehicleId = newMaintenanceVehicle.Id,
                    PartId = partId,
                    MaintenanceFinalPrice = part.MaintenancePrice,
                    MaintenanceServiceFinalPrice = part.MaintenanceServicePrice
                };

                await _maintenancePartRepository.AddMaintenancePartAsync(newMaintenancePart, cancellationToken);
            }
        }
        else if (!requestMaintenanceVehicles.Status.Equals(_maintenanceVehicleRepository.RequestMaintenance()))
        {
            // Update status maintenance vehicle
            await _maintenanceVehicleRepository.UpdateStatusAsync(requestMaintenanceVehicles,
                _maintenanceVehicleRepository.RequestMaintenance(), cancellationToken);

            // Create new maintenance parts
            foreach (var partId in request.ListPartId)
            {
                var part = await _partRepository.GetPartByIdAsync(partId, cancellationToken);

                var newMaintenancePart = new MaintenancePart
                {
                    MaintenanceVehicleId = requestMaintenanceVehicles.Id,
                    PartId = partId,
                    MaintenanceFinalPrice = part.MaintenancePrice,
                    MaintenanceServiceFinalPrice = part.MaintenanceServicePrice
                };

                await _maintenancePartRepository.AddMaintenancePartAsync(newMaintenancePart, cancellationToken);
            }
        }
        else
        {
            throw new BadRequestException("Kendaraan masih dalam proses permintaan perawatan");
        }

        // Update maintenance status in vehicle
        await _vehicleRepository.UpdateMaintenaceStatusVehicleAsync(vehicle,
            _maintenanceVehicleRepository.RequestMaintenance(), cancellationToken);

        // Create Notification
        var notification = new Notification
        {
            Title = "Perawatan Kendaraan",
            Description =
                $"Permintaan perawatan kendaraan {vehicle.Name} dengan plat nomor {vehicle.LicensePlate} anda berhasil, mohon ditunggu untuk info selanjutnya dari admin. Terimakasih",
            UserId = vehicle.UserId,
            Category = "admin"
        };

        await _notificationRepository.AddNotificationAsync(notification, cancellationToken);

        return new GenericResponseDto("Berhasil mengirim permintaan perawatan");
    }

    private static string GenerateTicket(int length)
    {
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var idBuilder = new StringBuilder();

        var random = new Random();
        for (var i = 0; i < length; i++)
        {
            var randomIndex = random.Next(characters.Length);
            idBuilder.Append(characters[randomIndex]);
        }

        return idBuilder.ToString();
    }
}