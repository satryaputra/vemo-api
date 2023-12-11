namespace Vemo.Application.Features.Auth.Commands.SendOtp;

/// <summary>
/// SendOtpCommandValidator
/// </summary>
public class SendOtpCommandValidator : AbstractValidator<SendOtpCommand>
{
    /// <summary>
    /// Initialize a new instance of the <see cref="SendOtpCommandValidator"/> class.
    /// </summary>
    public SendOtpCommandValidator()
    {
        RuleFor(x => x.AccessToken)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong");
        
        RuleFor(x => x.Email)
            .NotNull().WithMessage("{PropertyName} wajib diisi")
            .NotEmpty().WithMessage("{PropertyName} tidak boleh kosong")
            .EmailAddress().WithMessage("Format {PropertyName} salah");
    }
}