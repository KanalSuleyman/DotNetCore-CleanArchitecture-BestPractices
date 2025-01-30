using FluentValidation;

namespace BestPractice.Service.SampleEntities.Create;

/// <summary>
/// Validates the <see cref="CreateSampleEntityRequest"/> object using FluentValidation.
/// This class ensures that the request data meets the specified constraints before processing.
/// </summary>
public class CreateSampleEntityRequestValidator : AbstractValidator<CreateSampleEntityRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSampleEntityRequestValidator"/> class.
    /// Defines validation rules for the <see cref="CreateSampleEntityRequest"/> properties.
    /// </summary>
    public CreateSampleEntityRequestValidator()
    {
        // Name validation
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name field cannot be empty!")
            .Length(3, 33).WithMessage("Name field must be between 3 and 33 characters!");

        // Description validation
        RuleFor(x => x.Description)
            .NotNull().WithMessage("Description field is required")
            .Length(3, 77).WithMessage("Description field must be between 3 and 77 characters!");

        // Amount validation
        RuleFor(x => x.Amount)
            .InclusiveBetween(1, 100).WithMessage("Amount must be between 1 and 100");

        // CategoryId validation
        RuleFor(x => x.SampleEntityCategoryId)
            .NotNull().WithMessage("Category Id field is required")
            .GreaterThan(0).WithMessage("Category Id must be greater than 0");
    }
}