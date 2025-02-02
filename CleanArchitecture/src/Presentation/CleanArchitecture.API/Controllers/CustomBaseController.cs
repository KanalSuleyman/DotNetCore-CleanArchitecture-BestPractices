using System.Net;
using CleanArchitecture.Application;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

/// <summary>
/// Provides a base controller class for customizing action results based on <see cref="ServiceResult"/> or <see cref="ServiceResult"/>.
/// This class centralizes the logic for creating consistent HTTP responses.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CustomBaseController : ControllerBase
{
    /// <summary>
    /// Creates an <see cref="IActionResult"/> based on the provided <see cref="ServiceResult{T}"/>.
    /// This method handles different HTTP status codes such as NoContent, Created, and others.
    /// </summary>
    /// <typeparam name="T">The type of data in the service result.</typeparam>
    /// <param name="result">The service result to evaluate.</param>
    /// <returns>An <see cref="IActionResult"/> representing the HTTP response.</returns>
    [NonAction]
    public IActionResult CreateActionResult<T>(ServiceResult<T> result)
    {
        return result.StatusCode switch
        {
            HttpStatusCode.NoContent => NoContent(), // Returns 204 No Content.
            HttpStatusCode.Created => Created(result.UrlAsCreated, result), // Returns 201 Created with the resource location.
            _ => new ObjectResult(result) { StatusCode = result.StatusCode.GetHashCode() } // Returns a custom status code with the result.
        };
    }

    /// <summary>
    /// Creates an <see cref="IActionResult"/> based on the provided <see cref="ServiceResult"/>.
    /// This method handles different HTTP status codes such as NoContent and others.
    /// </summary>
    /// <param name="result">The service result to evaluate.</param>
    /// <returns>An <see cref="IActionResult"/> representing the HTTP response.</returns>
    [NonAction]
    public IActionResult CreateActionResult(ServiceResult result)
    {
        return result.StatusCode switch
        {
            HttpStatusCode.NoContent => new ObjectResult(null) { StatusCode = result.StatusCode.GetHashCode() }, // Returns 204 No Content.
            _ => new ObjectResult(result) { StatusCode = result.StatusCode.GetHashCode() } // Returns a custom status code with the result.
        };
    }
}