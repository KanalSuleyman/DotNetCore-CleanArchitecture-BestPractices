using CleanArchitecture.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace CleanArchitecture.API.ExceptionHandlers;

/// <summary>
/// Handles exceptions of type <see cref="CriticalException"/>.
/// This handler logs critical exceptions and simulates sending an SMS notification for immediate attention.
/// </summary>
public class CriticalExceptionHandler : IExceptionHandler
{
    /// <summary>
    /// Attempts to handle the exception asynchronously.
    /// If the exception is a <see cref="CriticalException"/>, it logs the exception and simulates sending an SMS notification.
    /// </summary>
    /// <param name="httpContext">The HTTP context associated with the request.</param>
    /// <param name="exception">The exception to handle.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A task representing the asynchronous operation. The task result indicates whether the exception was handled.</returns>
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        // Checks if the exception is of type CriticalException.
        if (exception is CriticalException)
            Console.WriteLine("Critical Exception is handled. An SMS Sent About the Critical Exception");

        // Returns false to indicate that the exception was not fully handled and should be processed by other handlers.
        return ValueTask.FromResult(false);
    }
}