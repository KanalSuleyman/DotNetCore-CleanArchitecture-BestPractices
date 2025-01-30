using BestPractice.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BestPractice.Service.Filters;

/// <summary>
/// Represents an action filter that checks if an entity exists in the database before executing the action.
/// If the entity does not exist, it returns a <see cref="NotFoundObjectResult"/> with a standardized error response.
/// </summary>
/// <typeparam name="T">The type of entity to check.</typeparam>
/// <typeparam name="TId">The type of the entity's identifier, which must be a value type.</typeparam>
/// <param name="genericRepository">The repository used to check for the existence of the entity.</param>
public class NotFoundFilter<T, TId>(IGenericRepository<T, TId> genericRepository)
    : Attribute, IAsyncActionFilter where T : class where TId : struct
{
    /// <summary>
    /// Executes the filter logic asynchronously.
    /// This method checks if the entity exists in the database and returns a "Not Found" response if it does not.
    /// </summary>
    /// <param name="context">The context for the action being executed.</param>
    /// <param name="next">The delegate to execute the next action filter or the action itself.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // Attempts to retrieve the 'id' parameter from the action arguments.
        var idValue = context.ActionArguments.TryGetValue("id", out var idAsObject) ? idAsObject : null;

        // Checks if the 'id' parameter is of the expected type TId.
        if (idAsObject is not TId id)
        {
            await next();
            return;
        }

        // Checks if the entity exists in the database using the generic repository.
        if (await genericRepository.AnyAsync(id))
        {
            await next();
            return;
        }

        // Constructs a standardized "Not Found" response if the entity does not exist.
        var entityName = typeof(T).Name;
        var actionName = context.ActionDescriptor.RouteValues["action"];

        var result = ServiceResult.Failure($"{entityName} not found in {actionName} action");
        context.Result = new NotFoundObjectResult(result);
    }
}