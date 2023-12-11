namespace Vemo.Application.Features.Auth.Commands.Login;

/// <summary>
/// LoginCommandValidator
/// </summary>
public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="LoginCommandValidator"/> class.
    /// </summary>
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong")
            .EmailAddress().WithMessage("Format {PropertyName} salah");
        
        RuleFor(x => x.Password)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong")
            .MinimumLength(8).WithMessage("{PropertyName} harus 8 karakter atau lebih")
            .Matches(@"[0-9]").WithMessage("{PropertyName} harus ada satu angka atau lebih");
    }
}