using Convey.CQRS.Commands;
using ProductWebAPI.Application.Command;
using ProductWebAPI.Core.Entity;
using ProductWebAPI.Core.Repository;

namespace ProductWebAPI.Application.CommandHandlers;

public class CreateProductHandler : ICommandHandler<CreateProduct>
{
    private readonly IProductRepository _repository;

    public CreateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    
    public async Task HandleAsync(CreateProduct command, CancellationToken cancellationToken = new CancellationToken())
    {
        var product = new Product()
        {
            Name = command.Name,
            ProductCategories = command.CategoryIds.Select(x => new ProductCategory
            {
                CategoryId = x
            }).ToList()
        };
        await _repository.CreateProduct(product);
    }
}