using CleanArchitecture.API.ExceptionHandlers;
using Microsoft.AspNetCore.Diagnostics;

namespace CleanArchitecture.API.Extensions
{
    public static class ExceptionHandlerExtension
    {
        /// <summary>
        /// Adds the exception handler services to the specified IServiceCollection.
        /// </summary>
        /// <param name="services">The service collection to which the exception handlers will be added.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddExceptionHandlerExtension(this IServiceCollection services)
        {
            // Register critical exception handler
            services.AddExceptionHandler<CriticalExceptionHandler>();
            // Register global exception handler
            services.AddExceptionHandler<GlobalExceptionHandler>();
            return services;
        }
    }
}
