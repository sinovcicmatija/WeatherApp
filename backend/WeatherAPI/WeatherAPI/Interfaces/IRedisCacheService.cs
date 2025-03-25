using System;
using System.Threading.Tasks;

namespace WeatherAPI.Interfaces
{
    public interface IRedisCacheService
    {
        Task SetAsync<T>(string key, T value, TimeSpan expirationTime);
        Task<T?> GetAsync<T>(string key);
    }
}
