using FluentValidation;

namespace CleanArchitecture.Application.Features.SampleEntityCategory.Create;

/// <summary>
/// Validates the <see cref="CreateSampleEntityCategoryRequest"/> object using FluentValidation.
/// This class ensures that the request data meets the specified constraints before processing.
/// </summary>
public class CreateSampleEntityCategoryRequestValidator : AbstractValidator<CreateSampleEntityCategoryRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSampleEntityCategoryRequestValidator"/> class.
    /// Defines validation rules for the <see cref="CreateSampleEntityCategoryRequest"/> properties.
    /// </summary>
    public CreateSampleEntityCategoryRequestValidator()
    {
        // Name validation
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name field cannot be empty!")
            .Length(3, 33).WithMessage("Name field must be between 3 and 33 characters!");
    }
}