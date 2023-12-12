using Vemo.Application.Features.Vehicles.Commands.AddVehicle;
using Vemo.Application.Features.Vehicles.Commands.ApproveVehicle;
using Vemo.Application.Features.Vehicles.Queries.GetVehicleById;

namespace Vemo.Api.Controllers;

/// <summary>
/// Represents RESTful of User
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
}