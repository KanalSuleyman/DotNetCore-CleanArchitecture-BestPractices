using CleanArchitecture.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitecture.API.Filters;

/// <summary>
/// Represents an action filter that validates the model state using FluentValidation.
/// If the model state is invalid, this filter returns a <see cref="BadRequestObjectResult"/> with the validation errors.
/// </summary>
public class FluentValidationFilter : IAsyncActionFilter
{
    /// <summary>
    /// Executes the filter logic asynchronously.
    /// This method checks the model state and returns a validation error response if the state is invalid.
    /// </summary>
    /// <param name="context">The context for the action being executed.</param>
    /// <param name="next">The delegate to execute the next action filter or the action itself.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // Checks if the model state is invalid.
        if (!context.ModelState.IsValid)
        {
            // Extracts the validation errors from the model state.
            var errors = context.ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage)
                .ToList();

            // Creates a failure result with the validation errors.
            var resultModel = ServiceResult.Failure(errors);

            // Returns a bad request response with the validation errors.
            context.Result = new BadRequestObjectResult(resultModel);

            return;
        }

        // Continues with the next action filter or the action itself.
        await next();
    }
}