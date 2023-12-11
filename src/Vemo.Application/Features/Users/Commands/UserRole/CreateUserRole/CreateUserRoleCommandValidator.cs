namespace Vemo.Application.Features.Users.Commands.UserRole.CreateUserRole;

/// <summary>
/// CreateUserRoleCommandValidator
/// </summary>
public class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="CreateUserRoleCommandValidator"/> class.
    /// </summary>
    public CreateUserRoleCommandValidator()
    {
        RuleFor(x => x.Role)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong")
            .Must(role => role is "Admin" or "Customer").WithMessage("{PropertyName} harus 'Admin' atau 'Customer'");
    }
}