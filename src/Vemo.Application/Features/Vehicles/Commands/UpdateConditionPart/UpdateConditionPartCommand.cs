namespace Vemo.Application.Features.Vehicles.Commands.UpdateConditionPart;

/// <summary>
/// UpdateConditionPartCommand
/// </summary>
public class UpdateConditionPartCommand : IRequest<object>
{
    /// <summary>
    /// Gets or sets ConditionPartId
    /// </summary>
    public Guid ConditionPartId { get; set; }

    /// <summary>
    /// Gets or sets NewLastMaintenanceDate
    /// </summary>
    public string NewLastMaintenanceDate { get; set; } = string.Empty;
}