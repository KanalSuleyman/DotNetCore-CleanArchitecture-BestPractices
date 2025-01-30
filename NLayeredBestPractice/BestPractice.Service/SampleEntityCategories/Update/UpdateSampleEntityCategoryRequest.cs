namespace BestPractice.Service.SampleEntityCategories.Update;

/// <summary>
/// Represents a request object for updating an existing <see cref="BestPractice.Repository.SampleEntityCategories.SampleEntityCategory"/>.
/// This record encapsulates the data required to update a sample entity category.
/// </summary>
/// <param name="Name">The updated name of the sample entity category.</param>
public record UpdateSampleEntityCategoryRequest(string Name);