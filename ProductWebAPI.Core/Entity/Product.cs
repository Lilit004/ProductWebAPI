namespace ProductWebAPI.Core.Entity;

public class Product
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public List<ProductCategory> ProductCategories { get; set; }
}