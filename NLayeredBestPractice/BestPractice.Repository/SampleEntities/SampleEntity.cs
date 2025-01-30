using BestPractice.Repository.SampleEntityCategories;

namespace BestPractice.Repository.SampleEntities;

/// <summary>
/// Represents a sample entity with associated properties and foreign key to its category.
/// Inherits from BaseEntity and implements IAuditEntity to track timestamps.
/// </summary>
public class SampleEntity : BaseEntity<int>, IAuditEntity
{
    /// <summary>
    /// Name of the entity.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Amount associated with the entity, typically monetary or quantitative.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Optional description of the entity.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Foreign key reference to the associated category.
    /// </summary>
    public int SampleEntityCategoryId { get; set; }

    /// <summary>
    /// Navigation property to the associated category.
    /// </summary>
    public SampleEntityCategory SampleEntityCategory { get; set; } = default!;

    /// <summary>
    /// The date and time when the entity was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The date and time when the entity was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}