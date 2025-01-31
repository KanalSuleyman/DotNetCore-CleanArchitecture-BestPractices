namespace CleanArchitecture.Application.Features.SampleEntity.Create;

/// <summary>
/// Represents a response object returned after successfully creating a <see cref="CleanArchitecture.Domain.Entities.SampleEntity"/>.
/// This record contains the identifier of the newly created entity.
/// </summary>
/// <param name="Id">The unique identifier of the created sample entity.</param>
public record CreateSampleEntityResponse(int Id);