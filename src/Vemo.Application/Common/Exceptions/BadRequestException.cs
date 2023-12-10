namespace Vemo.Application.Common.Exceptions;

/// <summary>
/// BadRequestException
/// </summary>
public class BadRequestException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestException"/> class.
    /// </summary>
    /// <param name="message"></param>
    public BadRequestException(string message) : base(message)
    {
    }
}