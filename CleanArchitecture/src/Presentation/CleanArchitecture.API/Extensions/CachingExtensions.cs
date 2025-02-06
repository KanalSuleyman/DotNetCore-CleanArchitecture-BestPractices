using CleanArchitecture.Application.Contracts.Caching;
using CleanArchitecture.Caching;

namespace CleanArchitecture.API.Extensions
{
    public static class CachingExtensions
    {
        public static IServiceCollection AddMemoryCacheExtension(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheService, CacheService>();
            return services;
        }
    }
}
