using FluentValidation;
using ProductWebAPI.Application.Command;
using ProductWebAPI.Core.Repository;

namespace ProductWebAPI.Application.Validator;

public class UpdateProductValidator : AbstractValidator<UpdateProduct>
{
    public UpdateProductValidator(IProductRepository pRepository, ICategoryRepository cRepository)
    {
        RuleFor(c => c.Id).Must(x =>
        {
            var result = pRepository.GetProductById(x).Result;
            return result != null;
        }).WithMessage("Product not found");
        
        RuleFor(x => x.Name).NotNull().WithMessage("Product name is required")
            .MinimumLength(2).WithMessage("Product name must be at least 2 characters long")
            .MaximumLength(100).WithMessage("Product name cannot exceed 100 characters");

        RuleFor(x => x.CategoryIds).NotNull().NotEmpty().WithMessage("Product must have category")
            .Must(ids =>
            {
                foreach (int id in ids)
                {
                    var result = cRepository.GetCategoryById(id).Result;
                    if (result == null)
                        return false;
                }
                return true;
            }).WithMessage("Category not found");
    }
}