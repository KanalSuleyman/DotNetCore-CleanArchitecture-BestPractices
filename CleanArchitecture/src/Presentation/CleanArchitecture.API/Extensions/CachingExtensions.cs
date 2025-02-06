using CleanArchitecture.Application.Contracts.Caching;
using CleanArchitecture.Caching;

namespace CleanArchitecture.API.Extensions
{
    /// <summary>
    /// Provides extension methods for configuring caching services in the application.
    /// </summary>
    public static class CachingExtensions
    {
        /// <summary>
        /// Adds memory caching services to the specified IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to configure.</param>
        /// <returns>The updated IServiceCollection with caching services added.</returns>
        public static IServiceCollection AddMemoryCacheExtension(this IServiceCollection services)
        {
            // Adds the default in-memory caching services to the service collection
            services.AddMemoryCache();

            // Registers the CacheService as a singleton implementation of ICacheService
            services.AddSingleton<ICacheService, CacheService>();

            // Returns the modified IServiceCollection for further configuration
            return services;
        }
    }
}
