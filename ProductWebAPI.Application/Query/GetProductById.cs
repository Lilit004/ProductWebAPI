using Convey.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.Application.DTO;

namespace ProductWebAPI.Application.Query;

public class GetProductById : IQuery<ProductDto>
{
    [FromRoute(Name = "id")]
    public long Id { get; set; }
}