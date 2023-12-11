namespace Vemo.Application.Features.Auth.Commands.ResetPassword;

/// <summary>
/// ResetPasswordCommandValidator
/// </summary>
public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="ResetPasswordCommandValidator"/> class.
    /// </summary>
    public ResetPasswordCommandValidator()
    {
        RuleFor(x => x.Token)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong");
        
        RuleFor(x => x.NewPassword)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong")
            .MinimumLength(8).WithMessage("{PropertyName} harus 8 karakter atau lebih")
            .Matches(@"[0-9]").WithMessage("{PropertyName} harus ada satu angka atau lebih");
    }
}