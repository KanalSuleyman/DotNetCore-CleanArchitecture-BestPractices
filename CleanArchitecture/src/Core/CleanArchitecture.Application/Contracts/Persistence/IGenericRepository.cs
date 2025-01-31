using System.Linq.Expressions;

namespace CleanArchitecture.Application.Contracts.Persistence;

/// <summary>
/// Defines a generic repository interface for performing CRUD operations on entities of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of entity managed by the repository.</typeparam>
/// <typeparam name="TId">The type of the entity's identifier, which must be a value type.</typeparam>
public interface IGenericRepository<T, in TId> where T : class where TId : struct
{
    /// <summary>
    /// Retrieves all entities from the repository as a queryable collection.
    /// </summary>
    /// <returns>An <see cref="IQueryable{T}"/> representing the collection of entities.</returns>
    IQueryable<T> GetAll();

    Task<List<T>> GetAllAsync();

    Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize);


    /// <summary>
    /// Checks asynchronously if an entity with the specified identifier exists in the repository.
    /// </summary>
    /// <param name="id">The identifier of the entity to check.</param>
    /// <returns>A task representing the asynchronous operation. The task result is <c>true</c> if the entity exists; otherwise, <c>false</c>.</returns>
    Task<bool> AnyAsync(TId id);

    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Filters entities based on the specified predicate and returns them as a queryable collection.
    /// </summary>
    /// <param name="predicate">A function to test each entity for a condition.</param>
    /// <returns>An <see cref="IQueryable{T}"/> representing the filtered collection of entities.</returns>
    IQueryable<T> Where(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Retrieves an entity by its identifier asynchronously.
    /// </summary>
    /// <param name="id">The identifier of the entity to retrieve.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the entity if found; otherwise, <c>null</c>.</returns>
    ValueTask<T?> GetByIdAsync(int id);

    /// <summary>
    /// Adds a new entity to the repository asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    ValueTask AddAsync(T entity);

    /// <summary>
    /// Updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    void Update(T entity);

    /// <summary>
    /// Deletes an entity from the repository.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    void Delete(T entity);
}