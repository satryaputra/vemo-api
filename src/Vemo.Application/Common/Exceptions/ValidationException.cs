using FluentValidation.Results;

namespace Vemo.Application.Common.Exceptions;

/// <summary>
/// RequestException
/// </summary>
public class ValidationException : Exception
{
    /// <summary>
    /// Gets or sets Errors
    /// </summary>
    public List<string> Errors { get; set; }
    
    /// <summary>
    /// Initializes a instance of the <see cref="ValidationException"/> class.
    /// </summary>
    public ValidationException()
    {
        Errors = new List<string>();
    }

    /// <summary>
    /// Initializes a instance of the <see cref="ValidationException"/> class.
    /// </summary>
    /// <param name="failures"></param>
    public ValidationException(List<ValidationFailure> failures) : this()
    {
        foreach (var failure in failures)
        {
            Errors.Add(failure.ErrorMessage);
        }
    }
}