namespace Vemo.Application.Common.Exceptions;

/// <summary>
/// ConflictException
/// </summary>
public class ConflictException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConflictException"/> class.
    /// </summary>
    /// <param name="message"></param>
    public ConflictException(string message) : base(message)
    {
    }
}