using Convey.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.Application.DTO;

namespace ProductWebAPI.Application.Query;

public class GetCategoryById : IQuery<CategoryDto>
{
    [FromRoute(Name = "id")]
    public long Id { get; set; }
}