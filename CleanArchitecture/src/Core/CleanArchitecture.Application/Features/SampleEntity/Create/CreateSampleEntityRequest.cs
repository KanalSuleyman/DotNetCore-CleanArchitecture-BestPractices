namespace CleanArchitecture.Application.Features.SampleEntity.Create;

/// <summary>
/// Represents a request object for creating a new <see cref="CleanArchitecture.Domain.Entities.SampleEntity"/>.
/// This record encapsulates the data required to create a new sample entity.
/// </summary>
/// <param name="Name">The name of the sample entity.</param>
/// <param name="Amount">The monetary amount associated with the sample entity.</param>
/// <param name="Description">An optional description of the sample entity.</param>
/// <param name="SampleEntityCategoryId">The identifier of the associated <see cref="BestPractice.Repository.SampleEntityCategories.SampleEntityCategory"/>.</param>
public record CreateSampleEntityRequest(string Name, decimal Amount, string? Description, int SampleEntityCategoryId);