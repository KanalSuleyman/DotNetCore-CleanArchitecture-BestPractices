using FluentValidation;

namespace BestPractice.Service.SampleEntityCategories.Update;

/// <summary>
/// Validates the <see cref="UpdateSampleEntityCategoryRequest"/> object using FluentValidation.
/// This class ensures that the request data meets the specified constraints before processing.
/// </summary>
public class UpdateSampleEntityCategoryRequestValidator : AbstractValidator<UpdateSampleEntityCategoryRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateSampleEntityCategoryRequestValidator"/> class.
    /// Defines validation rules for the <see cref="UpdateSampleEntityCategoryRequest"/> properties.
    /// </summary>
    public UpdateSampleEntityCategoryRequestValidator()
    {
        // Name validation
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name field cannot be empty!")
            .Length(3, 33).WithMessage("Name field must be between 3 and 33 characters!");
    }
}