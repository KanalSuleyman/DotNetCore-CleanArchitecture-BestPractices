﻿using System.Net;
using AutoMapper;
using BestPractice.Repository;
using BestPractice.Repository.SampleEntities;
using BestPractice.Service.SampleEntities.Create;
using BestPractice.Service.SampleEntities.Update;
using BestPractice.Service.SampleEntities.UpdateAmount;
using Microsoft.EntityFrameworkCore;

namespace BestPractice.Service.SampleEntities;

/// <summary>
/// Implements the <see cref="ISampleEntityService"/> interface to provide business logic for managing <see cref="SampleEntity"/> entities.
/// This service handles operations such as retrieval, creation, updating, and deletion of sample entities.
/// </summary>
/// <param name="sampleEntityRepository">The repository used to interact with the database.</param>
/// <param name="unitOfWork">The unit of work used to manage transactions.</param>
/// <param name="mapper">The AutoMapper instance used for object mapping.</param>
public class SampleEntityService(ISampleEntityRepository sampleEntityRepository, IUnitOfWork unitOfWork, IMapper mapper)
    : ISampleEntityService
{
    /// <inheritdoc />
    public async Task<ServiceResult<List<SampleEntityDto>>> GetTopAmountSampleEntitiesAsync(int count)
    {
        // Retrieves the top sample entities by amount.
        var sampleEntities = await sampleEntityRepository.GetTopAmountSampleEntitiesAsync(count);

        // Maps the entities to DTOs using AutoMapper.
        var sampleEntityDtos = mapper.Map<List<SampleEntityDto>>(sampleEntities);

        return new ServiceResult<List<SampleEntityDto>>
        {
            Data = sampleEntityDtos
        };
    }

    /// <inheritdoc />
    public async Task<ServiceResult<List<SampleEntityDto>>> GetAllAsync()
    {
        // Retrieves all sample entities from the repository.
        var sampleEntities = await sampleEntityRepository.GetAll().ToListAsync();

        // Maps the entities to DTOs using AutoMapper.
        var sampleEntityDtos = mapper.Map<List<SampleEntityDto>>(sampleEntities);

        return ServiceResult<List<SampleEntityDto>>.Success(sampleEntityDtos);
    }

    /// <inheritdoc />
    public async Task<ServiceResult<List<SampleEntityDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
    {
        // Retrieves a paged list of sample entities.
        var sampleEntities = await sampleEntityRepository.GetAll()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        // Maps the entities to DTOs using AutoMapper.
        var sampleEntityDtos = mapper.Map<List<SampleEntityDto>>(sampleEntities);

        return ServiceResult<List<SampleEntityDto>>.Success(sampleEntityDtos);
    }

    /// <inheritdoc />
    public async Task<ServiceResult<SampleEntityDto?>> GetByIdAsync(int id)
    {
        // Retrieves the sample entity by its identifier.
        var sampleEntity = await sampleEntityRepository.GetByIdAsync(id);

        // Returns a "Not Found" result if the entity does not exist.
        if (sampleEntity is null)
            return ServiceResult<SampleEntityDto?>.Failure("SampleEntity Not Found!", HttpStatusCode.NotFound);

        // Maps the entity to a DTO using AutoMapper.
        var sampleEntityDto = mapper.Map<SampleEntityDto>(sampleEntity);

        return ServiceResult<SampleEntityDto>.Success(sampleEntityDto)!;
    }

    /// <inheritdoc />
    public async Task<ServiceResult<CreateSampleEntityResponse>> CreateAsync(CreateSampleEntityRequest request)
    {
        // Checks if a sample entity with the same name already exists.
        var anySampleEntity = await sampleEntityRepository.Where(x => x.Name == request.Name).AnyAsync();

        // Returns a failure result if a duplicate name is found.
        if (anySampleEntity)
            return ServiceResult<CreateSampleEntityResponse>.Failure(
                "SampleEntity With the Same Name Already Exists!");

        // Maps the request to a SampleEntity and adds it to the repository.
        var sampleEntity = mapper.Map<SampleEntity>(request);
        await sampleEntityRepository.AddAsync(sampleEntity);
        await unitOfWork.SaveChangesAsync();

        // Returns a success result with the created entity's identifier.
        return ServiceResult<CreateSampleEntityResponse>.SuccessAsCreated(
            new CreateSampleEntityResponse(sampleEntity.Id), $"api/SampleEntities/{sampleEntity.Id}");
    }

    /// <inheritdoc />
    public async Task<ServiceResult> UpdateAsync(int id, UpdateSampleEntityRequest request)
    {
        // Checks if a sample entity with the same name already exists (excluding the current entity).
        var anySampleEntity = await sampleEntityRepository.Where(x => x.Name == request.Name && id != x.Id).AnyAsync();

        // Returns a failure result if a duplicate name is found.
        if (anySampleEntity)
            return ServiceResult.Failure("SampleEntity With the Same Name Already Exists!");

        // Maps the request to a SampleEntity and updates it in the repository.
        var sampleEntity = mapper.Map<SampleEntity>(request);
        sampleEntity.Id = id;
        sampleEntityRepository.Update(sampleEntity);

        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    /// <inheritdoc />
    public async Task<ServiceResult> UpdateAmountAsync(UpdateSampleEntityAmountRequest request)
    {
        // Retrieves the sample entity by its identifier.
        var sampleEntity = await sampleEntityRepository.GetByIdAsync(request.Id);

        // Returns a "Not Found" result if the entity does not exist.
        if (sampleEntity is null)
            return ServiceResult.Failure("SampleEntity Not Found!", HttpStatusCode.NotFound);

        // Updates the entity's amount and saves the changes.
        sampleEntity.Amount = request.Amount;
        sampleEntityRepository.Update(sampleEntity);

        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    /// <inheritdoc />
    public async Task<ServiceResult> DeleteAsync(int id)
    {
        // Retrieves the sample entity by its identifier.
        var sampleEntity = await sampleEntityRepository.GetByIdAsync(id);

        // Deletes the entity from the repository and saves the changes.
        sampleEntityRepository.Delete(sampleEntity!);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success(HttpStatusCode.NoContent);
    }
}