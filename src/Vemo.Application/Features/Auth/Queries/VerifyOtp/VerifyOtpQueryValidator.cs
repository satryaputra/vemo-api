namespace Vemo.Application.Features.Auth.Queries.VerifyOtp;

public class VerifyOtpQueryValidator : AbstractValidator<VerifyOtpQuery>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="VerifyOtpQueryValidator"/> class.
    /// </summary>
    public VerifyOtpQueryValidator()
    {
        RuleFor(x => x.AccessToken)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong");
        
        RuleFor(x => x.Otp)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .Must(otp => otp is >= 1000 and <= 9999).WithMessage("{PropertyName} harus 4 digit integer");
    }
}