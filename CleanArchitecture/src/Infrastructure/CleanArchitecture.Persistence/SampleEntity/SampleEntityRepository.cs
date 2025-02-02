using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.SampleEntity;

/// <summary>
/// Implements the <see cref="context"/> interface to provide repository methods
/// for <see cref="ISampleEntityRepository"/> entities.
/// </summary>
/// <param name="context">The database context used to perform operations.</param>
public class SampleEntityRepository(BestPracticeDbContext context)
    : GenericRepository<Domain.Entities.SampleEntity, int>(context), ISampleEntityRepository
{
    /// <summary>
    /// Retrieves a list of <see cref="SampleEntity"/> entities with the highest amounts, limited by the specified count.
    /// </summary>
    /// <param name="count">The maximum number of entities to retrieve.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the list of entities.</returns>
    public Task<List<Domain.Entities.SampleEntity>> GetTopAmountSampleEntitiesAsync(int count)
    {
        return Context.SampleEntities
            .OrderByDescending(x => x.Amount)
            .Take(count)
            .ToListAsync();
    }
}