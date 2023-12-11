namespace Vemo.Application.Features.Auth.Queries.ForgotPasswordRequest;

/// <summary>
/// ForgotPasswordRequestQueryValidator
/// </summary>
public class ForgotPasswordRequestQueryValidator : AbstractValidator<ForgotPasswordRequestQuery>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="ForgotPasswordRequestQueryValidator"/> class.
    /// </summary>
    public ForgotPasswordRequestQueryValidator()
    {
        RuleFor(x => x.Email)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong")
            .EmailAddress().WithMessage("Format {PropertyName} salah");
    }
}