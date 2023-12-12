using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vemo.Application.Features.Vehicles.Commands.AddVehicle;

namespace Vemo.Api.Controllers;

[Route("vehicles"), Authorize]
public class VehicleController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> AddVehicle(
        AddVehicleCommand addVehicleCommand,
        CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(addVehicleCommand, cancellationToken));
    }
}