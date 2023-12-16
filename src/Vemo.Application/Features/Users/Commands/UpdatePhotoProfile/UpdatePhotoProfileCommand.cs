namespace Vemo.Application.Features.Users.Commands.UpdatePhotoProfile;

/// <summary>
/// UpdatePhotoProfileCommand
/// </summary>
public class UpdatePhotoProfileCommand : IRequest<GenericResponseDto>
{
    /// <summary>
    /// Gets or sets AccessToken
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets ImageName
    /// </summary>
    public string ImageName { get; set; } = string.Empty;
}