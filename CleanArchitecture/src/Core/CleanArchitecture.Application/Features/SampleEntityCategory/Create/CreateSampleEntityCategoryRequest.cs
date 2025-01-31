namespace CleanArchitecture.Application.Features.SampleEntityCategory.Create;

/// <summary>
/// Represents a request object for creating a new <see cref="CleanArchitecture.Domain.Entities.SampleEntityCategory"/>.
/// This record encapsulates the data required to create a new sample entity category.
/// </summary>
/// <param name="Name">The name of the sample entity category.</param>
public record CreateSampleEntityCategoryRequest(string Name);