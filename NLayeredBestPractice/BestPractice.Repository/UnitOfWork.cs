namespace BestPractice.Repository;

/// <summary>
/// Implements the <see cref="IUnitOfWork"/> interface to provide a unit of work pattern
/// for managing database transactions and changes.
/// </summary>
/// <param name="context">The database context used to perform operations.</param>
public class UnitOfWork(BestPracticeDbContext context) : IUnitOfWork
{
    /// <summary>
    /// Asynchronously saves all changes made in the unit of work to the underlying database.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
    public Task<int> SaveChangesAsync()
    {
        return context.SaveChangesAsync();
    }
}