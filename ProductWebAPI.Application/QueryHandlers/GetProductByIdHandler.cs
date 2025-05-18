using Convey.CQRS.Queries;
using Microsoft.Extensions.Logging;
using ProductWebAPI.Application.DTO;
using ProductWebAPI.Application.Query;
using ProductWebAPI.Core.Repository;

namespace ProductWebAPI.Application.QueryHandlers;

public class GetProductByIdHandler : IQueryHandler<GetProductById, ProductDto>
{
    private readonly IProductRepository _repository;
    private readonly ILogger<GetProductByIdHandler> _logger;

    public GetProductByIdHandler(IProductRepository repository, ILogger<GetProductByIdHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<ProductDto> HandleAsync(GetProductById query, CancellationToken cancellationToken = new CancellationToken())
    {
        var product = await _repository.GetProductById(query.Id);
        if (product == null)
        {
            _logger.LogWarning("Product with id {id} not found.", query.Id);
            throw new Exception($"Product with id {query.Id} not found.");
        }
        var productDto = new ProductDto()
        {
            Id = product.Id,
            Name = product.Name,
            Categories = product.ProductCategories.Select(x => new CategoryDto()
            {
                Id = x.Category.Id,
                Name = x.Category.Name
            }).ToList()
        };
        return productDto;
    }
}