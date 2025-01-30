namespace BestPractice.Service.SampleEntities.Create;

/// <summary>
/// Represents a response object returned after successfully creating a <see cref="BestPractice.Repository.SampleEntities.SampleEntity"/>.
/// This record contains the identifier of the newly created entity.
/// </summary>
/// <param name="Id">The unique identifier of the created sample entity.</param>
public record CreateSampleEntityResponse(int Id);