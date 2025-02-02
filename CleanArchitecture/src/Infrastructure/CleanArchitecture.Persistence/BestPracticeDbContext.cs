using System.Reflection;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence;

/// <summary>
/// Represents the database context for the application, providing access to the underlying database
/// and managing entity sets and configurations.
/// </summary>
/// <param name="options">The options to be used by the database context.</param>
public class BestPracticeDbContext(DbContextOptions<BestPracticeDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> for <see cref="SampleEntity"/> entities.
    /// </summary>
    public DbSet<Domain.Entities.SampleEntity> SampleEntities { get; set; } = default!;

    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> for <see cref="SampleEntityCategory"/> entities.
    /// </summary>
    public DbSet<Domain.Entities.SampleEntityCategory> SampleEntityCategories { get; set; } = default!;

    /// <summary>
    /// Configures the model using entity configurations defined in the assembly.
    /// </summary>
    /// <param name="modelBuilder">The builder used to construct the model for the context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}