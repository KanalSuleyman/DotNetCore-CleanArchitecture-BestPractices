﻿using CleanArchitecture.API.Filters;

namespace CleanArchitecture.API.Extensions
{
    public static class ControllerExtensions
    {
        public static IServiceCollection AddControllersWithFilterExtension(this IServiceCollection services)
        {
            services.AddScoped(typeof(NotFoundFilter<,>));

            services.AddControllers(options =>
            {
                options.Filters.Add<FluentValidationFilter>();
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
            });

            return services;
        }
    }
}
