using BestPractice.Repository.SampleEntities;
using BestPractice.Service.Filters;
using BestPractice.Service.SampleEntities;
using BestPractice.Service.SampleEntities.Create;
using BestPractice.Service.SampleEntities.Update;
using BestPractice.Service.SampleEntities.UpdateAmount;
using Microsoft.AspNetCore.Mvc;

namespace BestPractice.API.Controllers;

/// <summary>
/// Provides API endpoints for managing <see cref="SampleEntity"/> entities.
/// This controller handles operations such as retrieval, creation, updating, and deletion of sample entities.
/// </summary>
public class SampleEntitiesController(ISampleEntityService sampleEntityService) : CustomBaseController
{
    /// <summary>
    /// Retrieves all sample entities.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> containing the list of sample entities.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll() => CreateActionResult(await sampleEntityService.GetAllAsync());

    /// <summary>
    /// Retrieves a paged list of sample entities.
    /// </summary>
    /// <param name="pageNumber">The page number to retrieve.</param>
    /// <param name="pageSize">The number of entities per page.</param>
    /// <returns>An <see cref="IActionResult"/> containing the paged list of sample entities.</returns>
    [HttpGet("{pageNumber:int}/{pageSize:int}")]
    public async Task<IActionResult> GetPagedAll(int pageNumber, int pageSize) =>
        CreateActionResult(await sampleEntityService.GetPagedAllListAsync(pageNumber, pageSize));

    /// <summary>
    /// Retrieves a sample entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the sample entity to retrieve.</param>
    /// <returns>An <see cref="IActionResult"/> containing the sample entity if found; otherwise, a "Not Found" response.</returns>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id) =>
        CreateActionResult(await sampleEntityService.GetByIdAsync(id));

    /// <summary>
    /// Creates a new sample entity.
    /// </summary>
    /// <param name="request">The request containing the data for the new entity.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the creation operation.</returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateSampleEntityRequest request) =>
        CreateActionResult(await sampleEntityService.CreateAsync(request));

    /// <summary>
    /// Updates an existing sample entity.
    /// </summary>
    /// <param name="id">The identifier of the sample entity to update.</param>
    /// <param name="request">The request containing the updated data.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the update operation.</returns>
    [ServiceFilter(typeof(NotFoundFilter<SampleEntity, int>))]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateSampleEntityRequest request) =>
        CreateActionResult(await sampleEntityService.UpdateAsync(id, request));

    /// <summary>
    /// Updates the amount of an existing sample entity.
    /// </summary>
    /// <param name="request">The request containing the updated amount.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the update operation.</returns>
    [HttpPatch("amount")]
    public async Task<IActionResult> UpdateAmount(UpdateSampleEntityAmountRequest request) =>
        CreateActionResult(await sampleEntityService.UpdateAmountAsync(request));

    /// <summary>
    /// Deletes a sample entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the sample entity to delete.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the deletion operation.</returns>
    [ServiceFilter(typeof(NotFoundFilter<SampleEntity, int>))]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        CreateActionResult(await sampleEntityService.DeleteAsync(id));
}