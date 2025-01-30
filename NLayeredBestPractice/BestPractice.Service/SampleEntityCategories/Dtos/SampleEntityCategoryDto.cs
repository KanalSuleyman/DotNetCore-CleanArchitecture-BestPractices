namespace BestPractice.Service.SampleEntityCategories.Dtos;

/// <summary>
/// Represents a data transfer object (DTO) for the <see cref="BestPractice.Repository.SampleEntityCategories.SampleEntityCategory"/> class.
/// This DTO is used to transfer data between layers without exposing the domain model.
/// </summary>
/// <param name="Id">The unique identifier of the sample entity category.</param>
/// <param name="Name">The name of the sample entity category.</param>
public record SampleEntityCategoryDto(int Id, string Name);