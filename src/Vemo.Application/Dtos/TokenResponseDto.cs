namespace Vemo.Application.Dtos;

/// <summary>
/// TokenResponseDto
/// </summary>
public class TokenResponseDto
{
    /// <summary>
    /// Gets or sets AccessToken
    /// </summary>
    public string AccessToken { get; set; }

    /// <summary>
    /// Gets or sets RefreshToken
    /// </summary>
    public string RefreshToken { get; set; }
    
    /// <summary>
    /// Gets or sets RefreshTokenExpires
    /// </summary>
    public DateTime RefreshTokenExpires { get; set; }

    /// <summary>
    /// Initialize a new instance of the <see cref="TokenResponseDto"/> class.
    /// </summary>
    /// <param name="accessToken"></param>
    /// <param name="refreshToken"></param>
    /// <param name="refreshTokenExpires"></param>
    public TokenResponseDto(string accessToken, string refreshToken, DateTime refreshTokenExpires)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        RefreshTokenExpires = refreshTokenExpires;
    }
}

/// <summary>
/// TokenResponseDto
/// </summary>
public class TokenCreateUserResponseDto
{
    /// <summary>
    /// Gets or sets UserId
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Gets or sets AccessToken
    /// </summary>
    public string AccessToken { get; set; }

    /// <summary>
    /// Gets or sets RefreshToken
    /// </summary>
    public string RefreshToken { get; set; }
    
    /// <summary>
    /// Gets or sets RefreshTokenExpires
    /// </summary>
    public DateTime RefreshTokenExpires { get; set; }

    /// <summary>
    /// Initialize a new instance of the <see cref="TokenResponseDto"/> class.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="accessToken"></param>
    /// <param name="refreshToken"></param>
    /// <param name="refreshTokenExpires"></param>
    public TokenCreateUserResponseDto(Guid userId, string accessToken, string refreshToken, DateTime refreshTokenExpires)
    {
        UserId = userId;
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        RefreshTokenExpires = refreshTokenExpires;
    }
}