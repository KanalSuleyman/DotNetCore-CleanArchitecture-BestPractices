using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Options;
using CleanArchitecture.Persistence.Interceptors;
using CleanArchitecture.Persistence.SampleEntity;
using CleanArchitecture.Persistence.SampleEntityCategory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence.Extensions;

/// <summary>
/// Provides extension methods for configuring and adding repository-related services to the dependency injection container.
/// </summary>
public static class RepositoryExtensions
{
    /// <summary>
    /// Adds repository-related services, including the database context, unit of work, and specific repositories, to the service collection.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <param name="configuration">The configuration used to retrieve connection strings and other settings.</param>
    /// <returns>The service collection with repository services added.</returns>
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        // Configures the database context with SQL Server and adds interceptors.
        services.AddDbContext<BestPracticeDbContext>(options =>
        {
            var connectionStrings = configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();

            options.UseSqlServer(connectionStrings!.SqlServer,
                sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.MigrationsAssembly(typeof(PersistenceAssembly).Assembly.FullName);
                });

            options.AddInterceptors(new AuditDbContextInterceptor());
        });

        // Registers generic and specific repositories in the dependency injection container.
        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ISampleEntityRepository, SampleEntityRepository>();
        services.AddScoped<ISampleEntityCategoryRepository, SampleEntityCategoryRepository>();

        return services;
    }
}