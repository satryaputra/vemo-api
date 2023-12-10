namespace Vemo.Application.Common.Exceptions;

/// <summary>
/// UnauthorizedException
/// </summary>
public class UnauthorizedException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnauthorizedException"/> class.
    /// </summary>
    /// <param name="message"></param>
    public UnauthorizedException(string message) : base(message)
    {
    }
}