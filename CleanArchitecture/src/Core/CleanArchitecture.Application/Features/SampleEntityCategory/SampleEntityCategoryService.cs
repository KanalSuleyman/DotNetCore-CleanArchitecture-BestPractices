using System.Net;
using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.SampleEntityCategory.Create;
using CleanArchitecture.Application.Features.SampleEntityCategory.Dto;
using CleanArchitecture.Application.Features.SampleEntityCategory.Update;

namespace CleanArchitecture.Application.Features.SampleEntityCategory;

/// <summary>
/// Implements the <see cref="ISampleEntityCategoryService"/> interface to provide business logic for managing <see cref="SampleEntityCategory"/> entities.
/// This service handles operations such as retrieval, creation, updating, and deletion of sample entity categories.
/// </summary>
/// <param name="sampleEntityCategoryRepository">The repository used to interact with the database.</param>
/// <param name="mapper">The AutoMapper instance used for object mapping.</param>
/// <param name="unitOfWork">The unit of work used to manage transactions.</param>
public class SampleEntityCategoryService(
    ISampleEntityCategoryRepository sampleEntityCategoryRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork) : ISampleEntityCategoryService
{
    /// <inheritdoc />
    public async Task<ServiceResult<SampleEntityCategoryWithSampleEntitiesDto>>
        GetSampleEntityCategoryWithSampleEntitiesAsync(int id)
    {
        // Retrieves the sample entity category by its identifier, including associated sample entities.
        var sampleEntityCategory =
            await sampleEntityCategoryRepository.GetSampleEntityCategoryWithSampleEntitiesAsync(id);

        // Returns a "Not Found" result if the category does not exist.
        if (sampleEntityCategory is null)
            return ServiceResult<SampleEntityCategoryWithSampleEntitiesDto>.Failure("Category not found!",
                HttpStatusCode.NotFound);

        // Maps the entity to a DTO using AutoMapper.
        var sampleEntityCategoryDto = mapper.Map<SampleEntityCategoryWithSampleEntitiesDto>(sampleEntityCategory);

        return ServiceResult<SampleEntityCategoryWithSampleEntitiesDto>.Success(sampleEntityCategoryDto);
    }

    /// <inheritdoc />
    public async Task<ServiceResult<List<SampleEntityCategoryWithSampleEntitiesDto>>>
        GetSampleEntityCategoryWithSampleEntitiesAsync()
    {
        // Retrieves a list of sample entity categories, including associated sample entities.
        var sampleEntityCategory =
            await sampleEntityCategoryRepository.GetSampleEntityCategoryWithSampleEntities();

        // Maps the entities to DTOs using AutoMapper.
        var sampleEntityCategoryDto = mapper.Map<List<SampleEntityCategoryWithSampleEntitiesDto>>(sampleEntityCategory);

        return ServiceResult<List<SampleEntityCategoryWithSampleEntitiesDto>>.Success(sampleEntityCategoryDto);
    }

    /// <inheritdoc />
    public async Task<ServiceResult<List<SampleEntityCategoryDto>>> GetAllListAsync()
    {
        // Retrieves a list of all sample entity categories.
        var sampleEntityCategory = await sampleEntityCategoryRepository.GetAllAsync();

        // Maps the entities to DTOs using AutoMapper.
        var sampleEntityCategoryDto = mapper.Map<List<SampleEntityCategoryDto>>(sampleEntityCategory);

        return ServiceResult<List<SampleEntityCategoryDto>>.Success(sampleEntityCategoryDto);
    }

    /// <inheritdoc />
    public async Task<ServiceResult<SampleEntityCategoryDto>> GetByIdAsync(int id)
    {
        // Retrieves the sample entity category by its identifier.
        var sampleEntityCategory = await sampleEntityCategoryRepository.GetByIdAsync(id);

        // Returns a "Not Found" result if the category does not exist.
        if (sampleEntityCategory is null)
            return ServiceResult<SampleEntityCategoryDto>.Failure("Category not found!", HttpStatusCode.NotFound);

        // Maps the entity to a DTO using AutoMapper.
        var sampleEntityCategoryDto = mapper.Map<SampleEntityCategoryDto>(sampleEntityCategory);

        return ServiceResult<SampleEntityCategoryDto>.Success(sampleEntityCategoryDto);
    }

    /// <inheritdoc />
    public async Task<ServiceResult<CreateSampleEntityCategoryResponse>> CreateAsync(
        CreateSampleEntityCategoryRequest request)
    {
        // Checks if a sample entity category with the same name already exists.
        var anySampleEntityCategory =
            await sampleEntityCategoryRepository.AnyAsync(x => x.Name == request.Name);

        // Returns a failure result if a duplicate name is found.
        if (anySampleEntityCategory)
            return ServiceResult<CreateSampleEntityCategoryResponse>.Failure(
                "Category with the same name is already exists!");

        // Maps the request to a SampleEntityCategory and adds it to the repository.
        var sampleEntityCategory = mapper.Map<Domain.Entities.SampleEntityCategory>(request);
        await sampleEntityCategoryRepository.AddAsync(sampleEntityCategory);
        await unitOfWork.SaveChangesAsync();

        // Returns a success result with the created category's identifier.
        return ServiceResult<CreateSampleEntityCategoryResponse>.SuccessAsCreated(
            new CreateSampleEntityCategoryResponse(sampleEntityCategory.Id),
            $"api/SampleEntityCategories/{sampleEntityCategory.Id}");
    }

    /// <inheritdoc />
    public async Task<ServiceResult> UpdateAsync(int id, UpdateSampleEntityCategoryRequest request)
    {
        // Checks if a sample entity category with the same name already exists (excluding the current category).
        var anySampleEntityCategory =
            await sampleEntityCategoryRepository.AnyAsync(x => x.Name == request.Name && id != x.Id);

        // Returns a failure result if a duplicate name is found.
        if (anySampleEntityCategory) return ServiceResult.Failure("Category with the same name is already exists!");

        // Maps the request to a SampleEntityCategory and updates it in the repository.
        var sampleEntityCategory = mapper.Map<Domain.Entities.SampleEntityCategory>(request);
        sampleEntityCategory.Id = id;
        sampleEntityCategoryRepository.Update(sampleEntityCategory);

        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    /// <inheritdoc />
    public async Task<ServiceResult> DeleteAsync(int id)
    {
        // Retrieves the sample entity category by its identifier.
        var sampleEntityCategory = await sampleEntityCategoryRepository.GetByIdAsync(id);

        // Deletes the category from the repository and saves the changes.
        sampleEntityCategoryRepository.Delete(sampleEntityCategory!);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success(HttpStatusCode.NoContent);
    }
}