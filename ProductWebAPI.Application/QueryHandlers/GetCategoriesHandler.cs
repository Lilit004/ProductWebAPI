using Convey.CQRS.Queries;
using ProductWebAPI.Application.DTO;
using ProductWebAPI.Application.Query;
using ProductWebAPI.Core.Repository;

namespace ProductWebAPI.Application.QueryHandlers;

public class GetCategoriesHandler : IQueryHandler<GetCategories,List<CategoryDto>>
{
    private readonly ICategoryRepository _repository;

    public GetCategoriesHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<CategoryDto>> HandleAsync(GetCategories query, CancellationToken cancellationToken = new CancellationToken())
    {
        if (query.PageNumber <= 0 || query.PageSize <= 0)
            throw new Exception("Invalid parameters");
        int skip = (query.PageNumber-1) * query.PageSize;
        var categories = await _repository.GetCategories();
        var categoryDtos = categories.Select(x => new CategoryDto()
        {
            Id = x.Id,
            Name = x.Name
        }).Skip(skip).Take(query.PageSize).ToList();
        return categoryDtos;
    }
}