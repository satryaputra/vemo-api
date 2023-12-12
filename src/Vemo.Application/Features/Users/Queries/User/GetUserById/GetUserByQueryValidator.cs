namespace Vemo.Application.Features.Users.Queries.User.GetUserById;

/// <summary>
/// GetUserByQueryValidator
/// </summary>
public class GetUserByQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="GetUserByQueryValidator"/> class.
    /// </summary>
    public GetUserByQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong");
    }
}