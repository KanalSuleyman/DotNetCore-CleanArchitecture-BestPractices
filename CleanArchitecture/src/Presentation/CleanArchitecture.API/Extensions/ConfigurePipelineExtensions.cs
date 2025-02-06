namespace CleanArchitecture.API.Extensions
{
    /// <summary>
    /// Static class containing extension methods for configuring the application's request pipeline.
    /// </summary>
    public static class ConfigurePipelineExtensions
    {
        /// <summary>
        /// Extension method to set up the application's request pipeline.
        /// </summary>
        /// <param name="app">The WebApplication instance to configure.</param>
        /// <returns>The modified IApplicationBuilder for further configuration.</returns>
        public static IApplicationBuilder UseConfigurePipelineExtension(this WebApplication app)
        {
            // Configure a global exception handler to manage unhandled exceptions gracefully.
            app.UseExceptionHandler(x => { });

            // Adjust the HTTP request pipeline based on the application's environment.
            if (app.Environment.IsDevelopment())
            {
                // Activate Swagger UI for API documentation and testing in development mode.
                app.UseSwaggerExtension();
            }

            // Enforce HTTPS redirection for secure communication across the application.
            app.UseHttpsRedirection();

            // Enable authorization middleware to enforce security policies on incoming requests.
            app.UseAuthorization();

            // Return the modified application builder to allow for further configuration.
            return app;
        }
    }
}
