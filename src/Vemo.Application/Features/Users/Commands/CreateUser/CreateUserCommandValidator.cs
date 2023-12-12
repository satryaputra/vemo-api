namespace Vemo.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong")
            .MinimumLength(3).WithMessage("{PropertyName} harus 3 karakter atau lebih");
        
        RuleFor(x => x.Email)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong")
            .EmailAddress().WithMessage("Format {PropertyName} salah");
        
        RuleFor(x => x.Password)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong")
            .MinimumLength(8).WithMessage("{PropertyName} harus 8 karakter atau lebih")
            .Matches(@"[0-9]").WithMessage("{PropertyName} harus ada satu angka atau lebih");
        
        RuleFor(x => x.Role)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong")
            .Must(role => role is "admin" or "customer").WithMessage("{PropertyName} harus 'admin' atau 'customer'");
    }
}