using Common.Cache.Interfaces;
using Common.Cache.Settings;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Cache.Services
{
    public class MemoryCacheService : IMemoryCacheService
    {
        private readonly ICacheSettings _cacheSettings;
        private readonly MemoryCacheEntryOptions _cacheOptions;
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache, ICacheSettings cacheSettings)
        {
            _cacheSettings = cacheSettings ?? throw new ArgumentNullException(nameof(cacheSettings));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));

            _cacheOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddHours(_cacheSettings.AbsoluteExpirationInHours),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromMinutes(_cacheSettings.SlidingExpirationInMinutes)
            };
        }

        /// <summary>
        /// Get item from cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<T> Get<T>(string key)
        {
            string value = string.Empty;

            try
            {
                await Task.Run(() => _memoryCache.TryGetValue(key, out value));
            }catch(Exception ex)
            {
                throw new Exception("Failed to get value from cache", ex);
            }

            T obj = default(T);

            try
            {
                obj = JsonSerializer.Deserialize<T>(value);
            }
            catch (Exception ex)
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
        /// <exception cref="Exception"></exception>
        public async Task<string> Set(object value)
        {
            string key = Guid.NewGuid().ToString().Replace("-", string.Empty);

            try
            {
                await Task.Run(() => _memoryCache.Set(key, value));
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to set value in cache", ex);
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
        public async Task<string> Set(object value, Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions options)
        {
            string key = Guid.NewGuid().ToString().Replace("-", string.Empty);

            try
            {
                await Task.Run(() => _memoryCache.Set(key, value, new MemoryCacheEntryOptions()
                {
                    AbsoluteExpiration = options.AbsoluteExpiration,
                    AbsoluteExpirationRelativeToNow = options.AbsoluteExpirationRelativeToNow,
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = options.SlidingExpiration
                }));
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to set value in cache", ex);
            }

            return key;
        }

        /// <summary>
        /// Remove item from cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task Remove(string key)
        {
            try
            {
                await Task.Run(() => _memoryCache.Remove(key));
            }catch(Exception ex)
            {
                throw new Exception("Failed to remove value from cache", ex);
            }
        }
    }
}
