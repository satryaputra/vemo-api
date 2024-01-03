namespace Vemo.Application.Common.Interfaces;

public interface ICacheService
{
    Task<T?> GetDataAsync<T>(string key);
    Task SetDataAsync<T>(string key, T value, DateTime expiration);
    Task<List<Guid>> GetActiveUsersAsync();
}