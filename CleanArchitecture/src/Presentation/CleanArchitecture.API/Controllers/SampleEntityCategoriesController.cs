using CleanArchitecture.API.Filters;
using CleanArchitecture.Application.Features.SampleEntityCategory;
using CleanArchitecture.Application.Features.SampleEntityCategory.Create;
using CleanArchitecture.Application.Features.SampleEntityCategory.Update;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

/// <summary>
/// Provides API endpoints for managing <see cref="SampleEntityCategory"/> entities.
/// This controller handles operations such as retrieval, creation, updating, and deletion of sample entity categories.
/// </summary>
public class SampleEntityCategoriesController(ISampleEntityCategoryService sampleEntityCategoryService) : CustomBaseController
{
    /// <summary>
    /// Retrieves all sample entity categories.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> containing the list of sample entity categories.</returns>
    [HttpGet]
    public async Task<IActionResult> GetSampleEntityCategories() =>
        CreateActionResult(await sampleEntityCategoryService.GetAllListAsync());

    /// <summary>
    /// Retrieves a sample entity category by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the category to retrieve.</param>
    /// <returns>An <see cref="IActionResult"/> containing the category if found; otherwise, a "Not Found" response.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSampleEntityCategory(int id) =>
        CreateActionResult(await sampleEntityCategoryService.GetByIdAsync(id));

    /// <summary>
    /// Retrieves a sample entity category by its identifier, including its associated sample entities.
    /// </summary>
    /// <param name="id">The identifier of the category to retrieve.</param>
    /// <returns>An <see cref="IActionResult"/> containing the category and its associated entities if found; otherwise, a "Not Found" response.</returns>
    [HttpGet("{id}/sample-entities")]
    public async Task<IActionResult> GetSampleEntityCategoryWithSampleEntities(int id) =>
        CreateActionResult(await sampleEntityCategoryService.GetSampleEntityCategoryWithSampleEntitiesAsync(id));

    /// <summary>
    /// Retrieves a list of sample entity categories, including their associated sample entities.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> containing the list of categories and their associated entities.</returns>
    [HttpGet("sample-entities")]
    public async Task<IActionResult> GetSampleEntityCategoryWithSampleEntities() =>
        CreateActionResult(await sampleEntityCategoryService.GetSampleEntityCategoryWithSampleEntitiesAsync());

    /// <summary>
    /// Creates a new sample entity category.
    /// </summary>
    /// <param name="request">The request containing the data for the new category.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the creation operation.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateSampleEntityCategory(CreateSampleEntityCategoryRequest request) =>
        CreateActionResult(await sampleEntityCategoryService.CreateAsync(request));

    /// <summary>
    /// Updates an existing sample entity category.
    /// </summary>
    /// <param name="id">The identifier of the category to update.</param>
    /// <param name="request">The request containing the updated data.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the update operation.</returns>
    [ServiceFilter(typeof(NotFoundFilter<SampleEntityCategory, int>))]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSampleEntityCategory(int id, UpdateSampleEntityCategoryRequest request) =>
        CreateActionResult(await sampleEntityCategoryService.UpdateAsync(id, request));

    /// <summary>
    /// Deletes a sample entity category by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the category to delete.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the deletion operation.</returns>
    [ServiceFilter(typeof(NotFoundFilter<SampleEntityCategory, int>))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSampleEntityCategory(int id) =>
        CreateActionResult(await sampleEntityCategoryService.DeleteAsync(id));
}