namespace CleanArchitecture.Application.Features.SampleEntity.Dto;

/// <summary>
/// Represents a data transfer object (DTO) for the <see cref="CleanArchitecture.Domain.Entities.SampleEntity"/> class.
/// This DTO is used to transfer data between layers without exposing the domain model.
/// </summary>
/// <param name="Id">The unique identifier of the sample entity.</param>
/// <param name="Name">The name of the sample entity.</param>
/// <param name="Amount">The monetary amount associated with the sample entity.</param>
/// <param name="Description">An optional description of the sample entity.</param>
/// <param name="SampleEntityCategoryId">The identifier of the associated <see cref="CleanArchitecture.Domain.Entities.SampleEntityCategory"/>.</param>
public record SampleEntityDto(int Id, string Name, decimal Amount, string? Description, int SampleEntityCategoryId);