namespace Vemo.Application.Dtos;

/// <summary>
/// VehiclePartConditionResponseDto
/// </summary>
public class VehiclePartConditionResponseDto
{
    /// <summary>
    /// Gets or sets VehiclePartConditionId
    /// </summary>
    public Guid VehiclePartConditionId { get; set; }

    /// <summary>
    /// Gets or sets VehiclePartId
    /// </summary>
    public Guid VehiclePartId { get; set; }
    
    /// <summary>
    /// Gets or sets VehiclePartName
    /// </summary>
    public string VehiclePartName { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets Condition
    /// </summary>
    public int Condition { get; set; }
}