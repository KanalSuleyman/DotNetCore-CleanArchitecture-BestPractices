using BestPractice.Service.SampleEntities.Update;
using CleanArchitecture.Application.Features.SampleEntity.Create;
using CleanArchitecture.Application.Features.SampleEntity.Dto;
using CleanArchitecture.Application.Features.SampleEntity.UpdateAmount;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.SampleEntity;

/// <summary>
/// Defines the service interface for managing <see cref="SampleEntity"/> entities.
/// This interface provides methods for retrieving, creating, updating, and deleting sample entities.
/// </summary>
public interface ISampleEntityService
{
    /// <summary>
    /// Retrieves a list of sample entities with the highest amounts, limited by the specified count.
    /// </summary>
    /// <param name="count">The maximum number of entities to retrieve.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the list of entities.</returns>
    Task<ServiceResult<List<SampleEntityDto>>> GetTopAmountSampleEntitiesAsync(int count);

    /// <summary>
    /// Retrieves all sample entities.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result contains the list of entities.</returns>
    Task<ServiceResult<List<SampleEntityDto>>> GetAllAsync();

    /// <summary>
    /// Retrieves a paged list of sample entities.
    /// </summary>
    /// <param name="pageNumber">The page number to retrieve.</param>
    /// <param name="pageSize">The number of entities per page.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the paged list of entities.</returns>
    Task<ServiceResult<List<SampleEntityDto>>> GetPagedAllListAsync(int pageNumber, int pageSize);

    /// <summary>
    /// Retrieves a sample entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity to retrieve.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the entity if found; otherwise, <c>null</c>.</returns>
    Task<ServiceResult<SampleEntityDto?>> GetByIdAsync(int id);

    /// <summary>
    /// Creates a new sample entity.
    /// </summary>
    /// <param name="request">The request containing the data for the new entity.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the created entity.</returns>
    Task<ServiceResult<CreateSampleEntityResponse>> CreateAsync(CreateSampleEntityRequest request);

    /// <summary>
    /// Updates an existing sample entity.
    /// </summary>
    /// <param name="id">The identifier of the entity to update.</param>
    /// <param name="request">The request containing the updated data.</param>
    /// <returns>A task representing the asynchronous operation. The task result indicates success or failure.</returns>
    Task<ServiceResult> UpdateAsync(int id, UpdateSampleEntityRequest request);

    /// <summary>
    /// Updates the amount of an existing sample entity.
    /// </summary>
    /// <param name="request">The request containing the updated amount.</param>
    /// <returns>A task representing the asynchronous operation. The task result indicates success or failure.</returns>
    Task<ServiceResult> UpdateAmountAsync(UpdateSampleEntityAmountRequest request);

    /// <summary>
    /// Deletes a sample entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity to delete.</param>
    /// <returns>A task representing the asynchronous operation. The task result indicates success or failure.</returns>
    Task<ServiceResult> DeleteAsync(int id);
}