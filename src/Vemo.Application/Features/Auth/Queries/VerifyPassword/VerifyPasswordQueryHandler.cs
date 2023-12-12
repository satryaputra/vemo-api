using Vemo.Application.Common.Exceptions;
using Vemo.Application.Common.Interfaces;
using Vemo.Application.Common.Utils;
using Vemo.Domain.Enums;

namespace Vemo.Application.Features.Auth.Queries.VerifyPassword;

/// <summary>
/// VerifyPasswordQueryHandler
/// </summary>
internal sealed class VerifyPasswordQueryHandler : IRequestHandler<VerifyPasswordQuery, GenericResponseDto>
{
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="VerifyPasswordQueryHandler"/> class.
    /// </summary>
    /// <param name="userRepository"></param>
    public VerifyPasswordQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GenericResponseDto> Handle(VerifyPasswordQuery request, CancellationToken cancellationToken)
    {
        var userId = TokenBuilder.GetUserIdFromJwtToken(request.AccessToken, TokenType.AccessToken);
        var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
        if (!PasswordHasher.VerifyPassword(request.Password, user.Password))
        {
            throw new BadRequestException("Password salah");
        }
        return new GenericResponseDto("Password benar");
    }
}