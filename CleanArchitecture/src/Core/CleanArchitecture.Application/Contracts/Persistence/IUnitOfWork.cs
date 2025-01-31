namespace CleanArchitecture.Application.Contracts.Persistence;

/// <summary>
/// Defines a unit of work interface for managing transactions and saving changes
/// asynchronously across multiple repositories.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Asynchronously saves all changes made in the unit of work to the underlying database.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync();
}