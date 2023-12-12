namespace Vemo.Application.Features.Users.Commands.UpdateUser;

/// <summary>
/// UpdateUserCommandValidator
/// </summary>
public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="UpdateUserCommandValidator"/> class.
    /// </summary>
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong");
        
        RuleFor(x => x.Name)
            .MinimumLength(3).WithMessage("{PropertyName} harus 3 karakter atau lebih");
        
        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Format {PropertyName} salah");
    }
}