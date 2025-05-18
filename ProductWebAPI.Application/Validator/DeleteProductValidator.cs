using FluentValidation;
using ProductWebAPI.Application.Command;
using ProductWebAPI.Core.Repository;

namespace ProductWebAPI.Application.Validator;

public class DeleteProductValidator : AbstractValidator<DeleteProduct>
{
    public DeleteProductValidator(IProductRepository repository)
    {
        RuleFor(c => c.Id).Must(x =>
        {
            var result = repository.GetProductById(x).Result;
            return result != null;
        }).WithMessage("Product not found");
    }
}