namespace Vemo.Application.Features.Users.Commands.UpdatePassword;

/// <summary>
/// UpdatePasswordCommandValidator
/// </summary>
public class UpdatePasswordCommandValidator : AbstractValidator<UpdatePasswordCommand>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="UpdatePasswordCommandValidator"/> class.
    /// </summary>
    public UpdatePasswordCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong");
        
        RuleFor(x => x.OldPassword)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong")
            .MinimumLength(8).WithMessage("{PropertyName} harus 8 karakter atau lebih")
            .Matches(@"[0-9]").WithMessage("{PropertyName} harus ada satu angka atau lebih");
        
        RuleFor(x => x.NewPassword)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong")
            .MinimumLength(8).WithMessage("{PropertyName} harus 8 karakter atau lebih")
            .Matches(@"[0-9]").WithMessage("{PropertyName} harus ada satu angka atau lebih");
    }
}