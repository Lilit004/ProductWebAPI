using ProductWebAPI.Core.Entity;

namespace ProductWebAPI.Core.Repository;

public interface IProductRepository
{
    Task CreateProduct(Product product);
    Task<Product?> GetProductById(long productId);
    Task<List<Product>> GetProducts();
    Task UpdateProduct(Product product);
    Task DeleteProduct(long productId);
}