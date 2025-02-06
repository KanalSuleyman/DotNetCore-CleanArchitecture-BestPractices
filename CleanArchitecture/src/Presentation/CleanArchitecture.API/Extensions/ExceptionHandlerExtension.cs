using CleanArchitecture.API.ExceptionHandlers;
using Microsoft.AspNetCore.Diagnostics;

namespace CleanArchitecture.API.Extensions
{
    public static class ExceptionHandlerExtension
    {
        public static IServiceCollection AddExceptionHandlerExtension(this IServiceCollection services)
        {
            services.AddExceptionHandler<CriticalExceptionHandler>();
            services.AddExceptionHandler<GlobalExceptionHandler>();
            return services;
        }
    }
}
