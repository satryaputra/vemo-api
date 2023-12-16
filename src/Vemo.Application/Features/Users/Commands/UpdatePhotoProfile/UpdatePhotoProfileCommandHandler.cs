using Vemo.Application.Common.Interfaces;
using Vemo.Application.Common.Utils;
using Vemo.Domain.Enums;

namespace Vemo.Application.Features.Users.Commands.UpdatePhotoProfile;

/// <summary>
/// UpdatePhotoProfileCommandHandler
/// </summary>
internal sealed class UpdatePhotoProfileCommandHandler : IRequestHandler<UpdatePhotoProfileCommand, GenericResponseDto>
{
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Initialize a new instance of the <see cref="UpdatePhotoProfileCommandHandler"/> class.
    /// </summary>
    /// <param name="userRepository"></param>
    public UpdatePhotoProfileCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GenericResponseDto> Handle(UpdatePhotoProfileCommand request, CancellationToken cancellationToken)
    {
        var userId = TokenBuilder.GetUserIdFromJwtToken(request.AccessToken, TokenType.AccessToken);
        await _userRepository.UpdatePhotoAsync(userId, request.ImageName, cancellationToken);
        return new GenericResponseDto("Berhasil memperbarui foto profile");
    }
}