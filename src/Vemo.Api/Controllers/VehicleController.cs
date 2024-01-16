using Vemo.Application.Features.Vehicles.Commands.AddVehicle;
using Vemo.Application.Features.Vehicles.Commands.ApproveVehicle;
using Vemo.Application.Features.Vehicles.Commands.CancelMaintenance;
using Vemo.Application.Features.Vehicles.Commands.ChangeMaintenancePrice;
using Vemo.Application.Features.Vehicles.Commands.ChangeStatusMaintenanceVehicle;
using Vemo.Application.Features.Vehicles.Commands.DoneMaintenance;
using Vemo.Application.Features.Vehicles.Commands.RequestMaintenance;
using Vemo.Application.Features.Vehicles.Queries.CountVehicles;
using Vemo.Application.Features.Vehicles.Queries.GetConditionPartsByVehicleId;
using Vemo.Application.Features.Vehicles.Queries.GetMaintenance;
using Vemo.Application.Features.Vehicles.Queries.GetMaintenanceById;
using Vemo.Application.Features.Vehicles.Queries.GetMaintenanceByVehicleId;
using Vemo.Application.Features.Vehicles.Queries.GetPartById;
using Vemo.Application.Features.Vehicles.Queries.GetPartsByVehicleId;
using Vemo.Application.Features.Vehicles.Queries.GetVehicleById;
using Vemo.Application.Features.Vehicles.Queries.GetVehicles;

namespace Vemo.Api.Controllers;

/// <summary>
/// Represents RESTful of Vehicle
/// </summary>
[Route("vehicles"), Authorize]
public class VehicleController : BaseController
{
    /// <summary>
    /// AddVehicle
    /// </summary>
    /// <param name="addVehicleCommand"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AddVehicle(
        AddVehicleCommand addVehicleCommand,
        CancellationToken cancellationToken)
    {
        return CreatedAtAction(
            nameof(GetVehicleById),
            new { vehicleId = await Mediator.Send(addVehicleCommand, cancellationToken) },
            new GenericResponseDto("Berhasil menambahkan kendaraan"));
    }

    /// <summary>
    /// GetVehicleById
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{vehicleId:guid}")]
    public async Task<IActionResult> GetVehicleById(
        [FromRoute] Guid vehicleId,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetVehicleByIdQuery { VehicleId = vehicleId }, cancellationToken));
    }

    /// <summary>
    /// GetVehicles
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="status"></param>
    /// <param name="maintenanceStatus"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetVehicles(
        [FromQuery] Guid? userId,
        [FromQuery] string? status,
        [FromQuery] string? maintenanceStatus,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(
            new GetVehiclesQuery { UserId = userId, Status = status, MaintenanceStatus = maintenanceStatus },
            cancellationToken));
    }

    /// <summary>
    /// ApproveVehicle
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("approve/{vehicleId:guid}")]
    public async Task<IActionResult> ApproveVehicle(
        [FromRoute] Guid vehicleId,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new ApproveVehicleCommand { VehicleId = vehicleId }, cancellationToken));
    }

    /// <summary>
    /// GetPartsByVehicleId
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("parts")]
    public async Task<IActionResult> GetPartsByVehicleId(
        [FromQuery] Guid vehicleId,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetPartByVehicleIdQuery { VehicleId = vehicleId }, cancellationToken));
    }

    /// <summary>
    /// GetPartById
    /// </summary>
    /// <param name="partId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("parts/{partId:guid}")]
    public async Task<IActionResult> GetPartById(
        [FromRoute] Guid partId,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetPartByIdQuery { PartId = partId }, cancellationToken));
    }

    /// <summary>
    /// GetConditionPartsByVehicleId
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{vehicleId:guid}/parts")]
    public async Task<IActionResult> GetConditionPartsByVehicleId(
        Guid vehicleId,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetConditionPartsByVehicleIdQuery
        {
            VehicleId = vehicleId
        }, cancellationToken));
    }

    /// <summary>
    /// RequestMaintenance
    /// </summary>
    /// <param name="requestMaintenanceCommand"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("maintenances")]
    public async Task<IActionResult> RequestMaintenance(
        RequestMaintenanceCommand requestMaintenanceCommand,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(requestMaintenanceCommand, cancellationToken));
    }

    /// <summary>
    /// GetMaintenanceVehicle
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("maintenances/{vehicleId:guid}/admin")]
    public async Task<IActionResult> GetMaintenanceVehicleAdmin([FromRoute] Guid vehicleId,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetMaintenanceByVehicleIdQuery { VehicleId = vehicleId }, cancellationToken));
    }

    /// <summary>
    /// GetMaintenanceVehicle
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("maintenances/{userId:guid}")]
    public async Task<IActionResult> GetMaintenanceVehicle([FromRoute] Guid userId,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetMaintenanceQuery { UserId = userId }, cancellationToken));
    }

    /// <summary>
    /// GetMaintenanceVehicleDetails
    /// </summary>
    /// <param name="maintenanceId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("maintenances/details/{maintenanceId:guid}")]
    public async Task<IActionResult> GetMaintenanceVehicleDetails([FromRoute] Guid maintenanceId,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetMaintenanceByIdQuery { MaintenanceId = maintenanceId },
            cancellationToken));
    }

    /// <summary>
    /// UpdateStatusMaintenanceVehicle
    /// </summary>
    /// <param name="changeStatusMaintenanceVehicleCommand"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch("maintenances/status"), Authorize(Roles = "admin")]
    public async Task<IActionResult> UpdateStatusMaintenanceVehicle(
        ChangeStatusMaintenanceVehicleCommand changeStatusMaintenanceVehicleCommand,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(changeStatusMaintenanceVehicleCommand, cancellationToken));
    }

    /// <summary>
    /// UpdatePriceMaintenancePart
    /// </summary>
    /// <param name="changeMaintenancePriceQuery"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch("maintenances/part/price")]
    public async Task<IActionResult> UpdatePriceMaintenancePart(ChangeMaintenancePriceQuery changeMaintenancePriceQuery,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(changeMaintenancePriceQuery, cancellationToken));
    }

    [HttpPost("maintenance/done")]
    public async Task<IActionResult> DoneMaintenance(DoneMaintenanceCommand doneMaintenanceCommand,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(doneMaintenanceCommand, cancellationToken));
    }

    [HttpPost("maintenance/cancel")]
    public async Task<IActionResult> CancelMaintenance(CancelMaintenanceCommand cancelMaintenanceCommand,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(cancelMaintenanceCommand, cancellationToken));
    }

    /// <summary>
    /// Count
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("count"), Authorize(Roles = "admin")]
    public async Task<IActionResult> Count(CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new CountVehiclesQuery(), cancellationToken));
    }
}