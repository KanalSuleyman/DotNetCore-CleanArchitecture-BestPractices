using CleanArchitecture.Application.Features.SampleEntityCategory.Create;
using CleanArchitecture.Application.Features.SampleEntityCategory.Dto;
using CleanArchitecture.Application.Features.SampleEntityCategory.Update;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.SampleEntityCategory;

/// <summary>
/// Defines the service interface for managing <see cref="SampleEntityCategory"/> entities.
/// This interface provides methods for retrieving, creating, updating, and deleting sample entity categories.
/// </summary>
public interface ISampleEntityCategoryService
{
    /// <summary>
    /// Retrieves a sample entity category by its identifier, including its associated sample entities.
    /// </summary>
    /// <param name="id">The identifier of the category to retrieve.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the category if found; otherwise, <c>null</c>.</returns>
    Task<ServiceResult<SampleEntityCategoryWithSampleEntitiesDto>>
        GetSampleEntityCategoryWithSampleEntitiesAsync(int id);

    /// <summary>
    /// Retrieves a list of sample entity categories, including their associated sample entities.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result contains the list of categories.</returns>
    Task<ServiceResult<List<SampleEntityCategoryWithSampleEntitiesDto>>>
        GetSampleEntityCategoryWithSampleEntitiesAsync();

    /// <summary>
    /// Retrieves a list of all sample entity categories.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result contains the list of categories.</returns>
    Task<ServiceResult<List<SampleEntityCategoryDto>>> GetAllListAsync();

    /// <summary>
    /// Retrieves a sample entity category by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the category to retrieve.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the category if found; otherwise, <c>null</c>.</returns>
    Task<ServiceResult<SampleEntityCategoryDto>> GetByIdAsync(int id);

    /// <summary>
    /// Creates a new sample entity category.
    /// </summary>
    /// <param name="request">The request containing the data for the new category.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the created category.</returns>
    Task<ServiceResult<CreateSampleEntityCategoryResponse>> CreateAsync(CreateSampleEntityCategoryRequest request);

    /// <summary>
    /// Updates an existing sample entity category.
    /// </summary>
    /// <param name="id">The identifier of the category to update.</param>
    /// <param name="request">The request containing the updated data.</param>
    /// <returns>A task representing the asynchronous operation. The task result indicates success or failure.</returns>
    Task<ServiceResult> UpdateAsync(int id, UpdateSampleEntityCategoryRequest request);

    /// <summary>
    /// Deletes a sample entity category by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the category to delete.</param>
    /// <returns>A task representing the asynchronous operation. The task result indicates success or failure.</returns>
    Task<ServiceResult> DeleteAsync(int id);
}