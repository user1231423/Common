using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache.Interfaces
{
    public interface IMemoryCacheService
    {
        Task<T> Get<T>(string key);

        Task<string> Set(object value);

        Task<string> Set(object value, DistributedCacheEntryOptions options);

        Task Remove(string key);
    }
}
