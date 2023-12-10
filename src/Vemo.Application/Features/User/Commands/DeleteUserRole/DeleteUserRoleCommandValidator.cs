namespace Vemo.Application.Features.User.Commands.DeleteUserRole;

/// <summary>
/// DeleteUserRoleCommandValidator
/// </summary>
public class DeleteUserRoleCommandValidator : AbstractValidator<DeleteUserRoleCommand>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="DeleteUserRoleCommandValidator"/> class.
    /// </summary>
    public DeleteUserRoleCommandValidator()
    {
        RuleFor(x => x.UserRoleId)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong");
    }
}