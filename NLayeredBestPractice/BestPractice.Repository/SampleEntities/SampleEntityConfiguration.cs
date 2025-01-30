using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestPractice.Repository.SampleEntities;

/// <summary>
/// Configures the entity model for the <see cref="SampleEntity"/> class.
/// This class defines the database schema and constraints for the <see cref="SampleEntity"/> entity.
/// </summary>
public class SampleEntityConfiguration : IEntityTypeConfiguration<SampleEntity>
{
    /// <summary>
    /// Configures the entity properties, relationships, and constraints for the <see cref="SampleEntity"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity.</param>
    public void Configure(EntityTypeBuilder<SampleEntity> builder)
    {
        // Defines the primary key for the entity.
        builder.HasKey(e => e.Id);

        // Configures the 'Name' property as required with a maximum length of 150 characters.
        builder.Property(e => e.Name).IsRequired().HasMaxLength(150);

        // Configures the 'Amount' property as required with a decimal precision of 18 and scale of 2.
        builder.Property(e => e.Amount).IsRequired().HasColumnType("decimal(18,2)");

        // Configures the 'Description' property as required with a maximum length of 500 characters.
        builder.Property(e => e.Description).IsRequired().HasMaxLength(500);
    }
}