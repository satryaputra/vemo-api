namespace Vemo.Application.Common.Exceptions;


/// <summary>
/// NotFoundException
/// </summary>
public class NotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    /// <param name="message"></param>
    public NotFoundException(string message) : base(message)
    {
    }
}