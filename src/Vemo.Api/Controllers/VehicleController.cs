using Vemo.Application.Features.Vehicles.Commands.AddVehicle;
using Vemo.Application.Features.Vehicles.Commands.ApproveVehicle;
using Vemo.Application.Features.Vehicles.Commands.RequestMaintenance;
using Vemo.Application.Features.Vehicles.Queries.CountVehicles;
using Vemo.Application.Features.Vehicles.Queries.GetConditionPartsByVehicleId;
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
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetVehicles(
        [FromQuery] Guid? userId,
        [FromQuery] string? status,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetVehiclesQuery { UserId = userId, Status = status }, cancellationToken));
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

    [HttpGet("maintenances/{vehicleId:guid}"), Authorize(Roles = "admin")]
    public async Task<IActionResult> GetMaintenanceVehicle([FromRoute] Guid vehicleId,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetMaintenanceByVehicleIdQuery { VehicleId = vehicleId }, cancellationToken));
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