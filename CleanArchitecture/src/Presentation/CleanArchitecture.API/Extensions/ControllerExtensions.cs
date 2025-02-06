using CleanArchitecture.API.Filters;

namespace CleanArchitecture.API.Extensions
{
    public static class ControllerExtensions
    {
        /// <summary>
        /// Adds controllers to the service collection with custom filters applied.
        /// </summary>
        /// <param name="services">The service collection to which the controllers are added.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddControllersWithFilterExtension(this IServiceCollection services)
        {
            // Register the NotFoundFilter for dependency injection
            services.AddScoped(typeof(NotFoundFilter<,>));

            // Configure the controllers with specific options
            services.AddControllers(options =>
            {
                // Add FluentValidationFilter to the global filter collection
                options.Filters.Add<FluentValidationFilter>();
                // Suppress implicit required attribute for non-nullable reference types
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
            });

            return services;
        }
    }
}
