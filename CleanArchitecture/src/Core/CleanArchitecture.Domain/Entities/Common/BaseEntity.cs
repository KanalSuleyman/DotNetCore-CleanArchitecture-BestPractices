namespace CleanArchitecture.Domain.Entities.Common;

/// <summary>
/// Base class for all entities, providing a generic Id property.
/// </summary>
/// <typeparam name="T">Type of the Id property, typically int or GUID.</typeparam>
public class BaseEntity<T>
{
    /// <summary>
    /// Unique identifier for the entity.
    /// </summary>
    public T Id { get; set; } = default!;
}