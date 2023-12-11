namespace Vemo.Api.Common.Utils;

/// <summary>
/// CookieSettings
/// </summary>
public static class CookieSettings
{
    /// <summary>
    /// AddExpires
    /// </summary>
    /// <param name="expires"></param>
    /// <returns></returns>
    public static CookieOptions AddExpires(DateTime expires)
    {
        return new CookieOptions
        {
            HttpOnly = true,
            Expires = expires,
            SameSite = SameSiteMode.None
        };
    }
}