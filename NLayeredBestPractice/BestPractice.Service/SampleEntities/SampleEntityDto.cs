namespace BestPractice.Service.SampleEntities;

/// <summary>
/// Represents a data transfer object (DTO) for the <see cref="BestPractice.Repository.SampleEntities.SampleEntity"/> class.
/// This DTO is used to transfer data between layers without exposing the domain model.
/// </summary>
/// <param name="Id">The unique identifier of the sample entity.</param>
/// <param name="Name">The name of the sample entity.</param>
/// <param name="Amount">The monetary amount associated with the sample entity.</param>
/// <param name="Description">An optional description of the sample entity.</param>
/// <param name="SampleEntityCategoryId">The identifier of the associated <see cref="BestPractice.Repository.SampleEntityCategories.SampleEntityCategory"/>.</param>
public record SampleEntityDto(int Id, string Name, decimal Amount, string? Description, int SampleEntityCategoryId);