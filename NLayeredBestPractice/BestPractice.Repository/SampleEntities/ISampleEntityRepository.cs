namespace BestPractice.Repository.SampleEntities;

/// <summary>
/// Defines a repository interface for <see cref="SampleEntity"/> entities, extending the generic repository.
/// This interface includes additional methods specific to <see cref="SampleEntity"/>.
/// </summary>
public interface ISampleEntityRepository : IGenericRepository<SampleEntity, int>
{
    /// <summary>
    /// Retrieves a list of <see cref="SampleEntity"/> entities with the highest amounts, limited by the specified count.
    /// </summary>
    /// <param name="count">The maximum number of entities to retrieve.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the list of entities.</returns>
    Task<List<SampleEntity>> GetTopAmountSampleEntitiesAsync(int count);
}