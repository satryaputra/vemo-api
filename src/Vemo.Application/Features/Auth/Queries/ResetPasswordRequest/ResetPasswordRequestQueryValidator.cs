using Vemo.Application.Features.Auth.Queries.ResetPasswordRequest;

namespace Vemo.Application.Features.Auth.Queries.ForgotPasswordRequest;

/// <summary>
/// ResetPasswordRequestQueryValidator
/// </summary>
public class ResetPasswordRequestQueryValidator : AbstractValidator<ResetPasswordRequestQuery>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="ResetPasswordRequestQueryValidator"/> class.
    /// </summary>
    public ResetPasswordRequestQueryValidator()
    {
        RuleFor(x => x.Email)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong")
            .EmailAddress().WithMessage("Format {PropertyName} salah");
    }
}