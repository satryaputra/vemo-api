namespace Vemo.Application.Features.Auth.Queries.VerifyPassword;

/// <summary>
/// VerifyPasswordQueryValidator
/// </summary>
public class VerifyPasswordQueryValidator : AbstractValidator<VerifyPasswordQuery>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="VerifyPasswordQueryValidator"/> class.
    /// </summary>
    public VerifyPasswordQueryValidator()
    {
        RuleFor(x => x.AccessToken)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong");
        
        RuleFor(x => x.Password)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong")
            .MinimumLength(8).WithMessage("{PropertyName} harus 8 karakter atau lebih")
            .Matches(@"[0-9]").WithMessage("{PropertyName} harus ada satu angka atau lebih");
    }
}