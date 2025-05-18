using FluentValidation;
using Microsoft.AspNetCore.Rewrite;
using ProductWebAPI.Application.Command;
using ProductWebAPI.Core.Repository;

namespace ProductWebAPI.Application.Validator;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategory>
{
    public UpdateCategoryValidator(ICategoryRepository repository)
    {
        RuleFor(c => c.Id).Must(x =>
        {
            var result = repository.GetCategoryById(x).Result;
            return result != null;
        }).WithMessage("Category not found");
        
        RuleFor(x => x.Name).NotNull().WithMessage("Category name is required")
            .MinimumLength(2).WithMessage("Category name must be at least 2 characters long")
            .MaximumLength(100).WithMessage("Category name cannot exceed 100 characters");
    }
}