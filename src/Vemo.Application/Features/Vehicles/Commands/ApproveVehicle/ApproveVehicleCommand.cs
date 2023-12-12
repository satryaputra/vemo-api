namespace Vemo.Application.Features.Vehicles.Commands.ApproveVehicle;

/// <summary>
/// ApproveVehicleCommand
/// </summary>
public class ApproveVehicleCommand : IRequest<GenericResponseDto>
{
    /// <summary>
    /// Gets or sets VehicleId
    /// </summary>
    public Guid VehicleId { get; set; }
}