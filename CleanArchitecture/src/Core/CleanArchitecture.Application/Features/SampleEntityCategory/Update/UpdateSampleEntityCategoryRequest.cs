namespace CleanArchitecture.Application.Features.SampleEntityCategory.Update;

/// <summary>
/// Represents a request object for updating an existing <see cref="CleanArchitecture.Domain.Entities.SampleEntityCategory"/>.
/// This record encapsulates the data required to update a sample entity category.
/// </summary>
/// <param name="Name">The updated name of the sample entity category.</param>
public record UpdateSampleEntityCategoryRequest(string Name);