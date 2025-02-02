using CleanArchitecture.API.Filters;

namespace CleanArchitecture.API.Extensions
{
    public static class ControllerExtensions
    {
        public static void AddControllersWithFilterExtension(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<FluentValidationFilter>();
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
            });
        }
    }
}
