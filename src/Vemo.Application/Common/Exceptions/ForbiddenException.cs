namespace Vemo.Application.Common.Exceptions;

/// <summary>
/// ForbiddenException
/// </summary>
public class ForbiddenException : Exception
{
    /// <summary>
    /// Initialize a new instance of the <see cref="ForbiddenException"/> class.
    /// </summary>
    /// <param name="message"></param>
    public ForbiddenException(string message) : base(message)
    {
    }
}