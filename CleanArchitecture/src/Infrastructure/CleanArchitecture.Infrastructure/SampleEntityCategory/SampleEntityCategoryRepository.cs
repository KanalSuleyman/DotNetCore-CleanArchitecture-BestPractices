using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.SampleEntityCategory;

/// <summary>
/// Implements the <see cref="context"/> interface to provide repository methods
/// for <see cref="ISampleEntityCategoryRepository"/> entities.
/// </summary>
/// <param name="context">The database context used to perform operations.</param>
public class SampleEntityCategoryRepository(BestPracticeDbContext context)
    : GenericRepository<Domain.Entities.SampleEntityCategory, int>(context), ISampleEntityCategoryRepository
{
    /// <summary>
    /// Retrieves a <see cref="SampleEntityCategory"/> entity by its identifier, including its associated <see cref="id"/> entities.
    /// </summary>
    /// <param name="id">The identifier of the category to retrieve.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the category if found; otherwise, <c>null</c>.</returns>
    public async Task<Domain.Entities.SampleEntityCategory?> GetSampleEntityCategoryWithSampleEntitiesAsync(int id)
    {
        return await context.SampleEntityCategories
            .Include(x => x.SampleEntities)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    /// <summary>
    /// Retrieves a queryable collection of <see cref="SampleEntityCategory"/> entities, including their associated <see cref="IQueryable{T}"/> entities.
    /// </summary>
    /// <returns>An <see cref="SampleEntity"/> representing the collection of categories with their associated entities.</returns>
    public async Task<List<Domain.Entities.SampleEntityCategory>> GetSampleEntityCategoryWithSampleEntities()
    {
        return await context.SampleEntityCategories
            .Include(x => x.SampleEntities)
            .ToListAsync();
    }
}