namespace Vemo.Application.Dtos;

/// <summary>
/// ResponseApiDto
/// </summary>
public class GenericResponseDto
{
    /// <summary>
    /// Gets or sets Message
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets Errors 
    /// </summary>
    public List<string> Errors { get; set; } = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenericResponseDto"/> class.
    /// </summary>
    /// <param name="message"></param>
    public GenericResponseDto(string message)
    {
        Message = message;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GenericResponseDto"/> class.
    /// </summary>
    /// <param name="errors"></param>
    public GenericResponseDto(List<string> errors)
        : this("Error")
    {
        Errors = errors;
    }
}