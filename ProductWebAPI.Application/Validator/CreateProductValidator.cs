using FluentValidation;
using ProductWebAPI.Application.Command;
using ProductWebAPI.Core.Repository;

namespace ProductWebAPI.Application.Validator;

public class CreateProductValidator : AbstractValidator<CreateProduct>
{
    public CreateProductValidator(ICategoryRepository repository)
    {
        RuleFor(x => x.Name).NotNull().WithMessage("Product name is required")
            .MinimumLength(2).WithMessage("Product name must be at least 2 characters long")
            .MaximumLength(100).WithMessage("Product name cannot exceed 100 characters");

        RuleFor(x => x.CategoryIds).NotNull().NotEmpty().WithMessage("Product must have category")
            .Must(ids =>
            {
                foreach (int id in ids)
                {
                    var result = repository.GetCategoryById(id).Result;
                    if (result == null)
                        return false;
                }
                return true;
            }).WithMessage("Category not found");
    }
}