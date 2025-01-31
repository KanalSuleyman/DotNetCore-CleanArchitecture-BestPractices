using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Contracts.Persistence;

/// <summary>
/// Defines a repository interface for <see cref="SampleEntityCategory"/> entities, extending the generic repository.
/// This interface includes additional methods specific to <see cref="SampleEntityCategory"/>.
/// </summary>
public interface ISampleEntityCategoryRepository : IGenericRepository<SampleEntityCategory, int>
{
    /// <summary>
    /// Retrieves a <see cref="SampleEntityCategory"/> entity by its identifier, including its associated <see cref="id"/> entities.
    /// </summary>
    /// <param name="id">The identifier of the category to retrieve.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the category if found; otherwise, <c>null</c>.</returns>
    Task<SampleEntityCategory?> GetSampleEntityCategoryWithSampleEntitiesAsync(int id);

    /// <summary>
    /// Retrieves a queryable collection of <see cref="SampleEntityCategory"/> entities, including their associated <see cref="IQueryable{T}"/> entities.
    /// </summary>
    /// <returns>An <see cref="SampleEntity"/> representing the collection of categories with their associated entities.</returns>
    Task<List<SampleEntityCategory>> GetSampleEntityCategoryWithSampleEntities();
}