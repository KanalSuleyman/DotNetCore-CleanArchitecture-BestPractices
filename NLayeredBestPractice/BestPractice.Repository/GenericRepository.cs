using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BestPractice.Repository;

/// <summary>
/// Implements the <see cref="IGenericRepository{T, TId}"/> interface to provide generic CRUD operations
/// for entities of type <typeparamref name="T"/> with an identifier of type <typeparamref name="TId"/>.
/// </summary>
/// <typeparam name="T">The type of entity managed by the repository. Must inherit from <see cref="BaseEntity{TId}"/>.</typeparam>
/// <typeparam name="TId">The type of the entity's identifier, which must be a value type.</typeparam>
/// <param name="context">The database context used to perform operations.</param>
public class GenericRepository<T, TId>(BestPracticeDbContext context) : IGenericRepository<T, TId> where T : BaseEntity<TId> where TId : struct
{
    /// <summary>
    /// The database context used to interact with the underlying database.
    /// </summary>
    protected BestPracticeDbContext Context = context;

    /// <summary>
    /// The database set for the entity type <typeparamref name="T"/>.
    /// </summary>
    private readonly DbSet<T> _dbSet = context.Set<T>();

    /// <summary>
    /// Retrieves all entities from the repository as a queryable collection.
    /// </summary>
    /// <returns>An <see cref="IQueryable{T}"/> representing the collection of entities.</returns>
    public IQueryable<T> GetAll() => _dbSet.AsQueryable().AsNoTracking();

    /// <summary>
    /// Checks asynchronously if an entity with the specified identifier exists in the repository.
    /// </summary>
    /// <param name="id">The identifier of the entity to check.</param>
    /// <returns>A task representing the asynchronous operation. The task result is <c>true</c> if the entity exists; otherwise, <c>false</c>.</returns>
    public Task<bool> AnyAsync(TId id) => _dbSet.AnyAsync(e => e.Id.Equals(id));

    /// <summary>
    /// Filters entities based on the specified predicate and returns them as a queryable collection.
    /// </summary>
    /// <param name="predicate">A function to test each entity for a condition.</param>
    /// <returns>An <see cref="IQueryable{T}"/> representing the filtered collection of entities.</returns>
    public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).AsNoTracking();

    /// <summary>
    /// Retrieves an entity by its identifier asynchronously.
    /// </summary>
    /// <param name="id">The identifier of the entity to retrieve.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the entity if found; otherwise, <c>null</c>.</returns>
    public ValueTask<T?> GetByIdAsync(int id) => _dbSet.FindAsync(id);

    /// <summary>
    /// Adds a new entity to the repository asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async ValueTask AddAsync(T entity) => await _dbSet.AddAsync(entity);

    /// <summary>
    /// Updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    public void Update(T entity) => _dbSet.Update(entity);

    /// <summary>
    /// Deletes an entity from the repository.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    public void Delete(T entity) => _dbSet.Remove(entity);
}