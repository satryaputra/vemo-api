namespace Vemo.Application.Dtos;

/// <summary>
/// ConditionPartResponseDto
/// </summary>
public class ConditionPartResponseDto
{
    /// <summary>
    /// Gets or sets VehiclePartConditionId
    /// </summary>
    public Guid ConditionPartId { get; set; }

    /// <summary>
    /// Gets or sets VehiclePartId
    /// </summary>
    public Guid PartId { get; set; }
    
    /// <summary>
    /// Gets or sets PartName
    /// </summary>
    public string PartName { get; set; } = string.Empty;

    private readonly int _condition;

    /// <summary>
    /// Gets or sets Condition
    /// </summary>
    public int Condition
    {
        get => _condition;
        init => _condition = CalculateCondition(value);
    }

    private static int CalculateCondition(int percentage)
    {
        return 100 - percentage;
    }
}