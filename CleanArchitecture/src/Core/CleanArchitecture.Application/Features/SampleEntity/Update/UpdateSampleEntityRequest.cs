namespace BestPractice.Service.SampleEntities.Update;

/// <summary>
/// Represents a request object for updating an existing <see cref="CleanArchitecture.Domain.Entities.SampleEntity"/>.
/// This record encapsulates the data required to update a sample entity.
/// </summary>
/// <param name="Name">The updated name of the sample entity.</param>
/// <param name="Amount">The updated monetary amount associated with the sample entity.</param>
/// <param name="Description">The updated description of the sample entity.</param>
/// <param name="SampleEntityCategoryId">The updated identifier of the associated <see cref="CleanArchitecture.Domain.Entities.SampleEntityCategory"/>.</param>
public record UpdateSampleEntityRequest(string Name, decimal Amount, string? Description, int SampleEntityCategoryId);