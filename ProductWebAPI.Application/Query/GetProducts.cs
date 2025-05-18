using Convey.CQRS.Queries;
using ProductWebAPI.Application.DTO;

namespace ProductWebAPI.Application.Query;

public class GetProducts : IQuery<List<ProductDto>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}