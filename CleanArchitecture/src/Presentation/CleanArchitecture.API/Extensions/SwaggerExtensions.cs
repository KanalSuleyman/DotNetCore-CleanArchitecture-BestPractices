namespace CleanArchitecture.API.Extensions
{
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Adds Swagger generation services to the specified IServiceCollection.
        /// </summary>
        /// <param name="services">The service collection to add Swagger services to.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddSwaggerGenExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "CleanArchitecture.API", Version = "v1" });
            });

            return services;
        }

        /// <summary>
        /// Configures the application to use Swagger and Swagger UI.
        /// </summary>
        /// <param name="app">The application builder to configure.</param>
        /// <returns>The updated application builder.</returns>
        public static IApplicationBuilder UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitecture.API V1"));
            return app;
        }
    }
}
