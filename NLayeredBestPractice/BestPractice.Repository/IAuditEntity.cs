namespace BestPractice.Repository;

/// <summary>
/// Interface to track entity creation and modification timestamps.
/// </summary>
public interface IAuditEntity
{
    /// <summary>
    /// The date and time when the entity was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The date and time when the entity was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}