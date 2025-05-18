using ProductWebAPI.Core.Entity;

namespace ProductWebAPI.Core.Repository;

public interface ICategoryRepository
{
    Task CreateCategory(Category category);
    Task<Category?> GetCategoryById(long categoryId);
    Task<List<Category>> GetCategories();
    Task UpdateCategory(Category category);
    Task DeleteCategory(long categoryId);

}