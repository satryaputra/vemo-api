namespace Vemo.Application.Common.Utils;

/// <summary>
/// DateTimeConverter
/// </summary>
public static class DateTimeConverter
{
    /// <summary>
    /// ToDateTimeUtc
    /// </summary>
    /// <param name="isoString"></param>
    /// <returns></returns>
    /// <exception cref="FormatException"></exception>
    public static DateTime ToDateTimeUtc(string isoString)
    {
        if (DateTimeOffset.TryParse(isoString, out var dateTimeOffset))
        {
            return dateTimeOffset.UtcDateTime;
        }
        else
        {
            throw new FormatException(
                $"Failed to parse the ISO string: {isoString}. Ensure it is a valid ISO 8601 string in UTC format.");
        }
    }
}