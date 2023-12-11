namespace Vemo.Application.Common.Utils;

/// <summary>
/// OtpBuilder
/// </summary>
public static class OtpBuilder
{
    /// <summary>
    /// Create
    /// </summary>
    /// <returns></returns>
    public static int CreateOtp()
    {
        var random = new Random();
        return random.Next(1000, 10000);
    }

    /// <summary>
    /// GetExpires
    /// </summary>
    /// <returns></returns>
    public static DateTime GetExpires()
    {
        return DateTime.UtcNow.AddHours(1);
    }
}