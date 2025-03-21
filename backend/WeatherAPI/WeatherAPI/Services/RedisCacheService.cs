﻿using StackExchange.Redis;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherAPI.Interfaces;

namespace WeatherAPI.Services
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDatabase _cache;

        public RedisCacheService(IConnectionMultiplexer redis)
        {
            _cache = redis.GetDatabase();
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expirationTime)
        {
            var jsonData = JsonSerializer.Serialize(value);
            await _cache.StringSetAsync(key, jsonData, expirationTime);
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var jsonData = await _cache.StringGetAsync(key);
            return jsonData.HasValue ? JsonSerializer.Deserialize<T>(jsonData!) : default;
        }
    }
}
