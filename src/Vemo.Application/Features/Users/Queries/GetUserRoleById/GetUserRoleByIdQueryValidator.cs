namespace Vemo.Application.Features.Users.Queries.GetUserRoleById;

/// <summary>
/// GetUserRoleByIdQueryValidator
/// </summary>
public class GetUserRoleByIdQueryValidator : AbstractValidator<GetUserRoleByIdQuery>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="GetUserRoleByIdQueryValidator"/> class.
    /// </summary>
    public GetUserRoleByIdQueryValidator()
    {
        RuleFor(x => x.UserRoleId)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong");
    }
}