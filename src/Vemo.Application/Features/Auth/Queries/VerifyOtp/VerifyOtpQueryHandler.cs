using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Application.Common.Utils;
using Vemo.Domain.Enums;

namespace Vemo.Application.Features.Auth.Queries.VerifyOtp;

/// <summary>
/// VerifyOtpQueryHandler
/// </summary>
internal sealed class VerifyOtpQueryHandler : IRequestHandler<VerifyOtpQuery, GenericResponseDto>
{
    private readonly IAuthInfoRepository _authInfoRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="VerifyOtpQueryHandler"/> class.
    /// </summary>
    /// <param name="authInfoRepository"></param>
    public VerifyOtpQueryHandler(IAuthInfoRepository authInfoRepository)
    {
        _authInfoRepository = authInfoRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="BadRequestException"></exception>
    public async Task<GenericResponseDto> Handle(VerifyOtpQuery request, CancellationToken cancellationToken)
    {
        var userId = TokenBuilder.GetUserIdFromJwtToken(request.AccessToken, TokenType.AccessToken);

        var userAuthInfo = await _authInfoRepository.GetAuthInfoByUserIdAsync(userId, cancellationToken);
        
        if (userAuthInfo.Otp != request.Otp)
            throw new BadRequestException("Kode otp salah");

        if (userAuthInfo.OtpExpires < DateTime.UtcNow)
            throw new BadRequestException("Kode otp sudah kadaluarsa");
        
        return new GenericResponseDto("Kode otp benar");
    }
}