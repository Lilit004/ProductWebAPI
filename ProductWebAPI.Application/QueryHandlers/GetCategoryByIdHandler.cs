using Convey.CQRS.Queries;
using Microsoft.Extensions.Logging;
using ProductWebAPI.Application.DTO;
using ProductWebAPI.Application.Query;
using ProductWebAPI.Core.Entity;
using ProductWebAPI.Core.Repository;

namespace ProductWebAPI.Application.QueryHandlers;

public class GetCategoryByIdHandler : IQueryHandler<GetCategoryById, CategoryDto>
{
    private readonly ICategoryRepository _repository;
    private readonly ILogger<GetCategoryByIdHandler> _logger;

    public GetCategoryByIdHandler(ICategoryRepository repository, ILogger<GetCategoryByIdHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<CategoryDto> HandleAsync(GetCategoryById query, CancellationToken cancellationToken = new CancellationToken())
    {
        var category = await _repository.GetCategoryById(query.Id);
        if (category == null)
        {
            _logger.LogWarning("Category with id {id} not found.", query.Id);
            throw new Exception($"Category with id {query.Id} not found.");
        }
        var categoryDto = new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name
        };
        return categoryDto;
    }
}