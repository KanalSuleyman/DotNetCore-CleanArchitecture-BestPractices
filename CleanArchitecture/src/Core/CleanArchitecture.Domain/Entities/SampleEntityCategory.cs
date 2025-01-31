using CleanArchitecture.Domain.Entities.Common;

namespace CleanArchitecture.Domain.Entities;

/// <summary>
/// Represents a category that can contain multiple SampleEntity objects.
/// Inherits from BaseEntity and implements IAuditEntity to track timestamps.
/// </summary>
public class SampleEntityCategory : BaseEntity<int>, IAuditEntity
{
    /// <summary>
    /// Name of the category.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// List of entities associated with this category.
    /// </summary>
    public List<SampleEntity>? SampleEntities { get; set; }

    /// <summary>
    /// The date and time when the category was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The date and time when the category was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}