using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vemo.Application.Dtos;
using Vemo.Application.Features.Vehicles.Commands.AddVehicle;
using Vemo.Application.Features.Vehicles.Queries.GetVehicleById;

namespace Vemo.Api.Controllers;

[Route("vehicles"), Authorize]
public class VehicleController : BaseController
{
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

    [HttpGet("{vehicleId:guid}")]
    public async Task<IActionResult> GetVehicleById(
        [FromRoute] Guid vehicleId,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetVehicleByIdQuery { VehicleId = vehicleId }, cancellationToken));
    }
}