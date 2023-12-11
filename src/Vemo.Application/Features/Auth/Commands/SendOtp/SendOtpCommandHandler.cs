using Vemo.Application.Common.Interfaces;
using Vemo.Application.Common.Utils;
using Vemo.Domain.Enums;

namespace Vemo.Application.Features.Auth.Commands.SendOtp;

/// <summary>
/// SendOtpCommandHandler
/// </summary>
internal sealed class SendOtpCommandHandler : IRequestHandler<SendOtpCommand, GenericResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserAuthInfoRepository _userAuthInfoRepository;
    private readonly IEmailService _emailService;

    /// <summary>
    /// Initialize a new instance of the <see cref="SendOtpCommandHandler"/> class.
    /// </summary>
    /// <param name="userAuthInfoRepository"></param>
    /// <param name="userRepository"></param>
    /// <param name="emailService"></param>
    public SendOtpCommandHandler(IUserAuthInfoRepository userAuthInfoRepository, IUserRepository userRepository, IEmailService emailService)
    {
        _userAuthInfoRepository = userAuthInfoRepository;
        _userRepository = userRepository;
        _emailService = emailService;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GenericResponseDto> Handle(SendOtpCommand request, CancellationToken cancellationToken)
    {
        var userId = TokenBuilder.GetUserIdFromJwtToken(request.AccessToken, TokenType.AccessToken);
        var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);

        var otp = OtpBuilder.CreateOtp();

        await _userAuthInfoRepository.AddNewOtpAsync(
            userId, 
            otp,
            OtpBuilder.GetExpires(),
            cancellationToken);

        var subjectEmail = "OTP Vemo App";
        var bodyEmail = @$"<p>Kode verifikasi otp untuk Vemo : <code>{otp}</code></p>";
        
        await _emailService.SendEmailAsync(request.Email, user.Name, subjectEmail, bodyEmail, cancellationToken);
        
        return new GenericResponseDto("Otp berhasil dikirim");
    }
}