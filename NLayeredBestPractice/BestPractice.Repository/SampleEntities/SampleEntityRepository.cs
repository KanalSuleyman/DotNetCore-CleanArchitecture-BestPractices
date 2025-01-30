using Microsoft.EntityFrameworkCore;

namespace BestPractice.Repository.SampleEntities;

/// <summary>
/// Implements the <see cref="ISampleEntityRepository"/> interface to provide repository methods
/// for <see cref="SampleEntity"/> entities.
/// </summary>
/// <param name="context">The database context used to perform operations.</param>
public class SampleEntityRepository(BestPracticeDbContext context)
    : GenericRepository<SampleEntity, int>(context), ISampleEntityRepository
{
    /// <summary>
    /// Retrieves a list of <see cref="SampleEntity"/> entities with the highest amounts, limited by the specified count.
    /// </summary>
    /// <param name="count">The maximum number of entities to retrieve.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the list of entities.</returns>
    public Task<List<SampleEntity>> GetTopAmountSampleEntitiesAsync(int count)
    {
        return Context.SampleEntities
            .OrderByDescending(x => x.Amount)
            .Take(count)
            .ToListAsync();
    }
}