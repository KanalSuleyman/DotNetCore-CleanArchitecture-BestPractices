namespace CleanArchitecture.Application.Features.SampleEntity.UpdateAmount;

/// <summary>
/// Represents a request object for updating the amount of an existing <see cref="CleanArchitecture.Domain.Entities.SampleEntity"/>.
/// This record encapsulates the data required to update the monetary amount of a sample entity.
/// </summary>
/// <param name="Id">The unique identifier of the sample entity to update.</param>
/// <param name="Amount">The updated monetary amount associated with the sample entity.</param>
public record UpdateSampleEntityAmountRequest(int Id, int Amount);