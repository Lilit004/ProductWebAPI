using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductWebAPI.Core.Entity;
using ProductWebAPI.Core.Repository;

namespace ProductWebAPI.Infrastructure.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _context;
    private readonly ILogger<ProductRepository> _logger;

    public ProductRepository(ProductDbContext context, ILogger<ProductRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public async Task CreateProduct(Product product)
    {
        await _context.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task<Product?> GetProductById(long productId)
    {
        var product = await _context.Products.Include(x => x.ProductCategories)
            .ThenInclude(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == productId);
        return product;
    }

    public async Task<List<Product>> GetProducts()
    {
        var products = await _context.Products.Include(x => x.ProductCategories)
            .ThenInclude(x => x.Category).ToListAsync();
        return products;
    }

    public async Task UpdateProduct(Product product)
    {
        var productToUpdate = await _context.Products.Include(p => p.ProductCategories)
            .FirstOrDefaultAsync(x => x.Id == product.Id);
        if (productToUpdate == null)
        {
            _logger.LogWarning("Update failed: Product with id {id} not found.", product.Id);
            throw new Exception($"Product with id {product.Id} not found.");
        }
        
        productToUpdate.Name = product.Name;
        
        _context.ProductCategories.RemoveRange(productToUpdate.ProductCategories);

        await _context.ProductCategories.AddRangeAsync(product.ProductCategories);

        await _context.SaveChangesAsync();
        _logger.LogInformation("Product with id {id} successfully updated.", product.Id);
    }

    public async Task DeleteProduct(long productId)
    {
        var product = await _context.Products.Include(p => p.ProductCategories)
            .FirstOrDefaultAsync(x => x.Id == productId);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        _logger.LogInformation("Product with id {id} successfully removed.", product.Id);
    }
}