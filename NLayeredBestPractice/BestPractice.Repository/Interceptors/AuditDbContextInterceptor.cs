using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BestPractice.Repository.Interceptors;

/// <summary>
/// Represents an interceptor for auditing changes to entities that implement the <see cref="IAuditEntity"/> interface.
/// This interceptor automatically sets the <see cref="IAuditEntity.CreatedAt"/> and <see cref="IAuditEntity.UpdatedAt"/>
/// timestamps when entities are added or modified.
/// </summary>
public class AuditDbContextInterceptor : SaveChangesInterceptor
{
    /// <summary>
    /// A dictionary mapping entity states to their corresponding audit behaviors.
    /// This allows for dynamic handling of audit logic based on the entity's state.
    /// </summary>
    private static readonly Dictionary<EntityState, Action<DbContext, IAuditEntity>> Behaviours = new()
    {
        { EntityState.Added, AddBehaviour }, // Behavior for newly added entities.
        { EntityState.Modified, UpdateBehaviour } // Behavior for modified entities.
    };

    /// <summary>
    /// Defines the behavior for newly added entities.
    /// Sets the <see cref="IAuditEntity.CreatedAt"/> timestamp and ensures the <see cref="IAuditEntity.UpdatedAt"/>
    /// property is not marked as modified.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="auditEntity">The entity being audited.</param>
    private static void AddBehaviour(DbContext context, IAuditEntity auditEntity)
    {
        auditEntity.CreatedAt = DateTime.Now;
        context.Entry(auditEntity).Property(a => a.UpdatedAt).IsModified = false;
    }

    /// <summary>
    /// Defines the behavior for modified entities.
    /// Sets the <see cref="IAuditEntity.UpdatedAt"/> timestamp and ensures the <see cref="IAuditEntity.CreatedAt"/>
    /// property is not marked as modified.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="auditEntity">The entity being audited.</param>
    private static void UpdateBehaviour(DbContext context, IAuditEntity auditEntity)
    {
        auditEntity.UpdatedAt = DateTime.Now;
        context.Entry(auditEntity).Property(a => a.CreatedAt).IsModified = false;
    }

    /// <summary>
    /// Intercepts the saving changes process to apply audit behaviors to entities that implement <see cref="IAuditEntity"/>.
    /// This method is called asynchronously before changes are saved to the database.
    /// </summary>
    /// <param name="eventData">Event data containing information about the context and changes being saved.</param>
    /// <param name="result">The result of the interception operation.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the interception result.</returns>
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new())
    {
        // Iterates through all entities in the change tracker.
        foreach (var entityEntry in eventData.Context!.ChangeTracker.Entries().ToList())
        {
            // Skips entities that do not implement the IAuditEntity interface.
            if (entityEntry.Entity is not IAuditEntity auditEntity) continue;

            // Skips entities that are not in the Added or Modified state.
            if (entityEntry.State is not EntityState.Added or EntityState.Modified) continue;

            // Applies the appropriate audit behavior based on the entity's state.
            Behaviours[entityEntry.State](eventData.Context, auditEntity);
        }

        // Continues with the default saving changes process.
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}