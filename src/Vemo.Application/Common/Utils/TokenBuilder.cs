using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Vemo.Application.Common.Exceptions;
using Vemo.Domain.Entities.Users;
using Vemo.Domain.Enums;

namespace Vemo.Application.Common.Utils;

/// <summary>
/// TokenBuilder
/// </summary>
public static class TokenBuilder
{
    private static readonly Dictionary<TokenType, string> SecretKeys = new()
    {
        { TokenType.AccessToken, "A26DCE0284E193689C5461C92356541F41F9376A2381325EC5EE72EB35FC4584" },
        { TokenType.ForgotPasswordToken, "A835BB93EEE76032C18AF7AA23F14E95A570AB1F2B6A5A11D174EEBA38C2009C" }
    };

    /// <summary>
    /// CreateAccessToken
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="userRole"></param>
    /// <returns></returns>
    public static string CreateAccessToken(Guid userId, string userRole)
    {
        return CreateJwtToken(userId, userRole, TokenType.AccessToken);
    }

    /// <summary>
    /// CreateRefreshToken
    /// </summary>
    /// <returns></returns>
    public static string CreateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }

    /// <summary>
    /// CreateForgotPasswordToken
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static string CreateForgotPasswordToken(Guid userId)
    {
        return CreateJwtToken(userId, TokenType.ForgotPasswordToken);
    }

    /// <summary>
    /// CreateToken
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="tokenType"></param>
    /// <returns></returns>
    private static string CreateJwtToken(Guid userId, TokenType tokenType)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(SecretKeys[tokenType]);

        var identityClaims = new List<Claim>
        {
            new("userId", userId.ToString())
        };

        var identity = new ClaimsIdentity(identityClaims);
        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = identity,
            SigningCredentials = credentials,
            Expires = GetJwtTokenExpired()
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        return jwtTokenHandler.WriteToken(token);
    }
    
    /// <summary>
    /// CreateToken
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="userRole"></param>
    /// <param name="tokenType"></param>
    /// <returns></returns>
    private static string CreateJwtToken(Guid userId, string userRole, TokenType tokenType)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(SecretKeys[tokenType]);

        var identityClaims = new List<Claim>
        {
            new("userId", userId.ToString()),
            new(ClaimTypes.Role, userRole)
        };

        var identity = new ClaimsIdentity(identityClaims);
        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = identity,
            SigningCredentials = credentials,
            Expires = GetJwtTokenExpired()
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        return jwtTokenHandler.WriteToken(token);
    }

    /// <summary>
    /// GetPrincipalFromToken
    /// </summary>
    /// <param name="token"></param>
    /// <param name="tokenType"></param>
    /// <returns></returns>
    /// <exception cref="UnauthorizedException"></exception>
    /// <exception cref="ForbiddenException"></exception>
    public static Guid GetUserIdFromJwtToken(string token, TokenType tokenType)
    {
        var key = Encoding.ASCII.GetBytes(SecretKeys[tokenType]);

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateLifetime = false,
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

        if (!IsValidSecurityToken(securityToken))
        {
            switch (tokenType)
            {
                case TokenType.AccessToken:
                    throw new UnauthorizedException("invalid_access_token");
                case TokenType.ForgotPasswordToken:
                    throw new UnauthorizedException("invalid_forgotpassword_token");
            }
        }

        var userIdClaim = principal.FindFirst("userId")?.Value ?? throw new BadRequestException("UserId kosong | userIdClaim");

        return Guid.Parse(userIdClaim);
    }

    /// <summary>
    /// IsValidSecurityToken
    /// </summary>
    /// <param name="securityToken"></param>
    /// <returns></returns>
    private static bool IsValidSecurityToken(ISafeLogSecurityArtifact securityToken)
    {
        return securityToken is JwtSecurityToken jwtSecurityToken &&
               jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                   StringComparison.InvariantCultureIgnoreCase);
    }
    
    /// <summary>
    /// IsValidRefreshToken
    /// </summary>
    /// <param name="userAuthInfo"></param>
    /// <param name="refreshTokenRequest"></param>
    /// <returns></returns>
    public static bool IsValidRefreshToken(UserAuthInfo userAuthInfo, string refreshTokenRequest)
    {
        return userAuthInfo.RefreshToken!.Equals(refreshTokenRequest) && userAuthInfo.RefreshTokenExpires >= DateTime.UtcNow;
    }

    /// <summary>
    /// GetJwtTokenExpired
    /// </summary>
    /// <returns></returns>
    private static DateTime GetJwtTokenExpired()
    {
        return DateTime.UtcNow.AddHours(1);
    }

    /// <summary>
    /// GetRefreshTokenExpired
    /// </summary>
    /// <returns></returns>
    public static DateTime GetRefreshTokenExpired()
    {
        return DateTime.UtcNow.AddDays(7);
    }
}