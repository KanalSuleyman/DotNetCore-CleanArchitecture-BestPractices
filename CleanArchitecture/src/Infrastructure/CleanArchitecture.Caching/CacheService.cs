using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Contracts.Caching;
using Microsoft.Extensions.Caching.Memory;

namespace CleanArchitecture.Caching
{
    public class CacheService(IMemoryCache memoryCache) : ICacheService
    {
        public Task<T?> GetCachedResponseAsync<T>(string cacheKey)
        {
            return Task.FromResult(memoryCache.TryGetValue(cacheKey, out T? cacheItem) ? cacheItem : default(T));
        }

        public Task AddCacheAsync<T>(string cacheKey, T value, TimeSpan timeToLive)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timeToLive
            };

            memoryCache.Set(cacheKey, value, cacheEntryOptions);

            return Task.CompletedTask;
        }

        public Task RemoveCacheAsync(string cacheKey)
        {
            memoryCache.Remove(cacheKey);

            return Task.CompletedTask;
        }
    }
}
