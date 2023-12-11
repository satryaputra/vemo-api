﻿using Vemo.Application.Common.Interfaces;
using Vemo.Application.Common.Utils;

namespace Vemo.Application.Features.Auth.Queries.ForgotPasswordRequest;

/// <summary>
/// ForgotPasswordRequestQueryHandler
/// </summary>
internal sealed class ForgotPasswordRequestQueryHandler : IRequestHandler<ForgotPasswordRequestQuery, GenericResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    /// <summary>
    /// Initialize a new instance of the <see cref="ForgotPasswordRequestQueryHandler"/> class.
    /// </summary>
    /// <param name="userRepository"></param>
    /// <param name="emailService"></param>
    public ForgotPasswordRequestQueryHandler(IUserRepository userRepository, IEmailService emailService)
    {
        _userRepository = userRepository;
        _emailService = emailService;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GenericResponseDto> Handle(ForgotPasswordRequestQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken);
        
        var forgotPasswordToken = TokenBuilder.CreateForgotPasswordToken(user.Id);

        var subjectEmail = "Forgot Password Vemo App";
        var bodyEmail = @$"<p>Klik link dibawah untuk reset password anda</p>
<a href='http://localhost:5173/forgot-password/{forgotPasswordToken}'>Reset Password</a>";

        await _emailService.SendEmailAsync(user.Email, user.Name, subjectEmail, bodyEmail, cancellationToken);

        return new GenericResponseDto("Link reset password telah berhasil dikirim ke email Anda");
    }
}