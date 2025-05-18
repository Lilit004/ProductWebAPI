using FluentValidation;
using ProductWebAPI.Application.Command;

namespace ProductWebAPI.Application.Validator;

public class CreateCategoryValidator : AbstractValidator<CreateCategory>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Name).NotNull().WithMessage("Category name is required")
            .MinimumLength(2).WithMessage("Category name must be at least 2 characters long")
            .MaximumLength(100).WithMessage("Category name cannot exceed 100 characters");
    }
}