using BestPractice.Repository.SampleEntities;
using BestPractice.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BestPractice.Service.ExceptionHandlers;
using BestPractice.Service.Filters;
using BestPractice.Service.SampleEntities;
using BestPractice.Service.SampleEntityCategories;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace BestPractice.Service.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<ISampleEntityService, SampleEntityService>();
            services.AddScoped<ISampleEntityCategoryService, SampleEntityCategoryService>();
            services.AddScoped(typeof(NotFoundFilter<,>));

            services.AddFluentValidationAutoValidation();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddExceptionHandler<CriticalExceptionHandler>();
            services.AddExceptionHandler<GlobalExceptionHandler>();
            return services;
        }
    }
}
