using CleanArchitecture.Application.Features.SampleEntity.Dto;

namespace CleanArchitecture.Application.Features.SampleEntityCategory.Dto;

/// <summary>
/// Represents a data transfer object (DTO) for the <see cref="id"/> class,
/// including a list of associated <see cref="name"/> objects.
/// This DTO is used to transfer data between layers without exposing the domain model.
/// </summary>
/// <param name="sampleEntities">The unique identifier of the sample entity category.</param>
/// <param name="name">The name of the sample entity category.</param>
/// <param name="sampleEntities">The list of associated sample entities.</param>
public record SampleEntityCategoryWithSampleEntitiesDto(int id, string name, List<SampleEntityDto> sampleEntities);