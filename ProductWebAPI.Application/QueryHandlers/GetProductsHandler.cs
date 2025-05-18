using Convey.CQRS.Queries;
using ProductWebAPI.Application.DTO;
using ProductWebAPI.Application.Query;
using ProductWebAPI.Core.Repository;

namespace ProductWebAPI.Application.QueryHandlers;

public class GetProductsHandler : IQueryHandler<GetProducts, List<ProductDto>>
{
    private readonly IProductRepository _repository;

    public GetProductsHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<ProductDto>> HandleAsync(GetProducts query, CancellationToken cancellationToken = new CancellationToken())
    {
        if (query.PageNumber <= 0 || query.PageSize <= 0)
            throw new Exception("Invalid parameters");
        int skip = (query.PageNumber - 1) * query.PageSize;
        var products = await _repository.GetProducts();
        List<ProductDto> productDtos = products.Select(x => new ProductDto
        {
            Id = x.Id,
            Name = x.Name,
            Categories = x.ProductCategories.Select(c => new CategoryDto
            {
                Id = c.Category.Id,
                Name = c.Category.Name
            }).ToList()
        }).ToList();
        productDtos = productDtos.Skip(skip).Take(query.PageSize).ToList();
        return productDtos;
    }
}