namespace Vemo.Application.Features.Auth.Commands.RefreshAccessToken;

public class RefreshAccessTokenCommandValidator : AbstractValidator<RefreshAccessTokenCommand>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="RefreshAccessTokenCommandValidator"/> class.
    /// </summary>
    public RefreshAccessTokenCommandValidator()
    {
        RuleFor(x => x.AccessToken)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong");
        
        RuleFor(x => x.RefreshToken)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong");
    }
}