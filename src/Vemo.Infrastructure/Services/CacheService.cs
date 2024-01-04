using System.Text.Json;
using StackExchange.Redis;
using Vemo.Application.Common.Interfaces;

namespace Vemo.Infrastructure.Services;

/// <summary>
/// CacheService
/// </summary>
public class CacheService : ICacheService
{
    private readonly IDatabase _cacheDb;

    /// <summary>
    /// Initialize a new instance of the <see cref="CacheService"/> class.
    /// </summary>
    public CacheService()
    {
        var redis = ConnectionMultiplexer.Connect("localhost:6379");
        _cacheDb = redis.GetDatabase();
    }

    /// <summary>
    /// GetDataAsync
    /// </summary>
    /// <param name="key"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public async Task<T?> GetDataAsync<T>(string key)
    {
        var value = await _cacheDb.StringGetAsync(key);
        return !string.IsNullOrEmpty(value) ? JsonSerializer.Deserialize<T>(value!) : default;
    }

    /// <summary>
    /// SetDataAsync
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="expiration"></param>
    /// <typeparam name="T"></typeparam>
    public async Task SetDataAsync<T>(string key, T value, DateTime expiration)
    {
        await _cacheDb.StringSetAsync(key, JsonSerializer.Serialize(value), expiration.Subtract(DateTime.UtcNow));
    }

    /// <summary>
    /// GetActiveUsersAsync
    /// </summary>
    /// <returns></returns>
    public async Task<List<Guid>> GetActiveUsersAsync()
    {
        var activeUsers = new List<Guid>();

        var redisServer = _cacheDb.Multiplexer.GetServer(_cacheDb.Multiplexer.GetEndPoints().First());
        const string pattern = "user-active:*";
        var keys = redisServer.Keys(pattern: pattern).ToArray();

        foreach (var key in keys)
        {
            var userId = await GetDataAsync<Guid?>(key!);
            if (!userId.HasValue) continue;
            var ttl = _cacheDb.KeyTimeToLive(key);
            if (ttl is { TotalMinutes: > 0 })
            {
                activeUsers.Add(userId.Value);
            }
        }

        return activeUsers;
    }
}