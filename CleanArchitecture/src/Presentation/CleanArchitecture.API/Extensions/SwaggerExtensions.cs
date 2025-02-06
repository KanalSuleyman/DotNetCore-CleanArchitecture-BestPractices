namespace CleanArchitecture.API.Extensions
{
    public static class SwaggerExtensions
    {
        
        public static IServiceCollection AddSwaggerGenExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new () { Title = "CleanArchitecture.API", Version = "v1" });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitecture.API V1"));
            return app;
        }

    }
}
