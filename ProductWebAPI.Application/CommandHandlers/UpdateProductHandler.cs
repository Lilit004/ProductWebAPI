using Convey.CQRS.Commands;
using ProductWebAPI.Application.Command;
using ProductWebAPI.Core.Entity;
using ProductWebAPI.Core.Repository;

namespace ProductWebAPI.Application.CommandHandlers;

public class UpdateProductHandler : ICommandHandler<UpdateProduct>
{
    private readonly IProductRepository _repository;

    public UpdateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    
    public async Task HandleAsync(UpdateProduct command, CancellationToken cancellationToken = new CancellationToken())
    {
        var product = new Product()
        {
            Id = command.Id,
            Name = command.Name,
            ProductCategories = command.CategoryIds.Select(x => new ProductCategory
            {
                ProductId = command.Id,
                CategoryId = x
            }).ToList()
        };
        await _repository.UpdateProduct(product);
    }
}