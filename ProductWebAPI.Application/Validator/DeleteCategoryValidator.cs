using FluentValidation;
using ProductWebAPI.Application.Command;
using ProductWebAPI.Core.Repository;

namespace ProductWebAPI.Application.Validator;

public class DeleteCategoryValidator : AbstractValidator<DeleteCategory>
{
    public DeleteCategoryValidator(ICategoryRepository repository)
    {
        RuleFor(c => c.Id).Must(x =>
        {
            var result = repository.GetCategoryById(x).Result;
            return result != null;
        }).WithMessage("Category not found");
    }
}