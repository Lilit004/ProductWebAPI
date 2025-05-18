using Convey.CQRS.Queries;
using ProductWebAPI.Application.DTO;

namespace ProductWebAPI.Application.Query;

public class GetCategories : IQuery<List<CategoryDto>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}