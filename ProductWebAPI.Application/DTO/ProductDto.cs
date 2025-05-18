namespace ProductWebAPI.Application.DTO;

public class ProductDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<CategoryDto> Categories { get; set; }
}