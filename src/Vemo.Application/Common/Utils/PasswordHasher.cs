using System.Security.Cryptography;

namespace Vemo.Application.Common.Utils;

/// <summary>
/// PasswordHasher
/// </summary>
public static class PasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 20;
    private const int Iterations = 10000;

    /// <summary>
    /// HashPassword
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public static string HashPassword(string password)
    {
        var salt = new byte[SaltSize];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        var key = new Rfc2898DeriveBytes(password, salt, Iterations);
        var hash = key.GetBytes(HashSize);

        var hashBytes = new byte[HashSize + SaltSize];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

        var base64Hash = Convert.ToBase64String(hashBytes);
        return base64Hash;
    }

    /// <summary>
    /// VerifyPassword
    /// </summary>
    /// <param name="password"></param>
    /// <param name="passwordHash"></param>
    /// <returns></returns>
    public static bool VerifyPassword(string password, string passwordHash)
    {
        var hashBytes = Convert.FromBase64String(passwordHash);

        var salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        var key = new Rfc2898DeriveBytes(password, salt, Iterations);
        var hash = key.GetBytes(HashSize);

        for (var i = 0; i < HashSize; i++)
        {
            if (hashBytes[i + SaltSize] != hash[i]) return false;
        }

        return true;
    }
}