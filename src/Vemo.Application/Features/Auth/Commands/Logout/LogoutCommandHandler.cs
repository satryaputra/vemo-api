using Vemo.Application.Common.Interfaces;
using Vemo.Application.Common.Utils;
using Vemo.Domain.Enums;

namespace Vemo.Application.Features.Auth.Commands.Logout;

/// <summary>
/// LogoutCommandHandler
/// </summary>
public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Unit>
{
    private readonly IAuthInfoRepository _authInfoRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="LogoutCommandHandler"/> class.
    /// </summary>
    /// <param name="authInfoRepository"></param>
    public LogoutCommandHandler(IAuthInfoRepository authInfoRepository)
    {
        _authInfoRepository = authInfoRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var userId = TokenBuilder.GetUserIdFromJwtToken(request.AccessToken, TokenType.AccessToken);
        await _authInfoRepository.DeleteRefreshTokenAsync(userId, cancellationToken);
        return Unit.Value;
    }
}