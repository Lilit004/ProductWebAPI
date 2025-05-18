using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductWebAPI.Core.Entity;
using ProductWebAPI.Core.Repository;

namespace ProductWebAPI.Infrastructure.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ProductDbContext _context;
    private readonly ILogger<CategoryRepository> _logger;

    public CategoryRepository(ProductDbContext context, ILogger<CategoryRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public async  Task CreateCategory(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task<Category?> GetCategoryById(long categoryId)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
        return category;
    }

    public async Task<List<Category>> GetCategories()
    {
        var categories = await _context.Categories.ToListAsync();
        return categories;
    }

    public async Task UpdateCategory(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
        _logger.LogInformation("Product with id {id} successfully updated.", category.Id);
    }

    public async Task DeleteCategory(long categoryId)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        _logger.LogInformation("Category with id {id} successfully removed.", category.Id);
    }
}