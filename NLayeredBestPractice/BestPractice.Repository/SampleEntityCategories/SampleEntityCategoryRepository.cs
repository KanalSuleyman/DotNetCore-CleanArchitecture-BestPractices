using Microsoft.EntityFrameworkCore;

namespace BestPractice.Repository.SampleEntityCategories;

/// <summary>
/// Implements the <see cref="ISampleEntityCategoryRepository"/> interface to provide repository methods
/// for <see cref="SampleEntityCategory"/> entities.
/// </summary>
/// <param name="context">The database context used to perform operations.</param>
public class SampleEntityCategoryRepository(BestPracticeDbContext context)
    : GenericRepository<SampleEntityCategory, int>(context), ISampleEntityCategoryRepository
{
    /// <summary>
    /// Retrieves a <see cref="SampleEntityCategory"/> entity by its identifier, including its associated <see cref="BestPractice.Repository.SampleEntities.SampleEntity"/> entities.
    /// </summary>
    /// <param name="id">The identifier of the category to retrieve.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the category if found; otherwise, <c>null</c>.</returns>
    public Task<SampleEntityCategory?> GetSampleEntityCategoryWithSampleEntitiesAsync(int id)
    {
        return context.SampleEntityCategories
            .Include(x => x.SampleEntities)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    /// <summary>
    /// Retrieves a queryable collection of <see cref="SampleEntityCategory"/> entities, including their associated <see cref="BestPractice.Repository.SampleEntities.SampleEntity"/> entities.
    /// </summary>
    /// <returns>An <see cref="IQueryable{T}"/> representing the collection of categories with their associated entities.</returns>
    public IQueryable<SampleEntityCategory?> GetSampleEntityCategoryWithSampleEntities()
    {
        return context.SampleEntityCategories
            .Include(x => x.SampleEntities)
            .AsQueryable();
    }
}