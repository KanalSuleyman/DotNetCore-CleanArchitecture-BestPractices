using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contracts.Caching
{
    public interface ICacheService
    {
        Task<T?> GetCachedResponseAsync<T>(string cacheKey);
        Task AddCacheAsync<T>(string cacheKey, T value, TimeSpan timeToLive);
        Task RemoveCacheAsync(string cacheKey);
    }
}
