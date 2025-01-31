using System.Reflection;
using CleanArchitecture.Application.Features.SampleEntity;
using CleanArchitecture.Application.Features.SampleEntityCategory;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<ISampleEntityService, SampleEntityService>();
            services.AddScoped<ISampleEntityCategoryService, SampleEntityCategoryService>();

            services.AddFluentValidationAutoValidation();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
