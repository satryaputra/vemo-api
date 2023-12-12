namespace Vemo.Application.Features.Users.Queries.User.GetCurrentUser;

/// <summary>
/// GetCurrentUserQueryValidator
/// </summary>
public class GetCurrentUserQueryValidator : AbstractValidator<GetCurrentUserQuery>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="GetCurrentUserQueryValidator"/> class.
    /// </summary>
    public GetCurrentUserQueryValidator()
    {
        RuleFor(x => x.AccessToken)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong");
    }
}