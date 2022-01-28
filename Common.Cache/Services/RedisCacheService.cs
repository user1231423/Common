using Common.Cache.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Cache.Services
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        /// <summary>
        /// Get item from cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<T> Get<T>(string key)
        {
            var value = string.Empty;

            try
            {
                value = await _cache.GetStringAsync(key);
            }catch(Exception ex)
            {
                throw new Exception("Failed to get item from cache", ex);
            }

            T obj = default(T);

            try
            {
                obj = JsonSerializer.Deserialize<T>(value);
            }catch(Exception ex)
            {
                throw new Exception("Failed to deserialize item", ex);
            }

            return obj;
        }

        /// <summary>
        /// Set item in cache
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<string> Set(object value)
        {
            string key = Guid.NewGuid().ToString().Replace("-", string.Empty);

            try
            {
                await _cache.SetStringAsync(key, JsonSerializer.Serialize(value));
            }catch(Exception ex)
            {
                throw new Exception("Failed to set item in cache", ex);
            }

            return key;
        }

        /// <summary>
        /// Set item in cache
        /// </summary>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<string> Set(object value, DistributedCacheEntryOptions options)
        {
            string key = Guid.NewGuid().ToString().Replace("-", string.Empty);

            try
            {
                await _cache.SetStringAsync(key, JsonSerializer.Serialize(value), options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to set item in cache", ex);
            }

            return key;
        }

        /// <summary>
        /// Remove item from cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task Remove(string key)
        {
            try
            {
                await _cache.RemoveAsync(key);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to remove item from cache", ex);
            }
        }
    }
}
