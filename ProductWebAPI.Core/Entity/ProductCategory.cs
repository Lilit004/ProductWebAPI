namespace ProductWebAPI.Core.Entity;

public class ProductCategory
{
    public long Id { get; set; }
    public long ProductId { get; set; }
    public long CategoryId { get; set; }
    
    public Category Category { get; set; }
    public Product Product { get; set; }
}