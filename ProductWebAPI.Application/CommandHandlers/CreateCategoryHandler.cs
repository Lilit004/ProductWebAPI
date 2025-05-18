using Convey.CQRS.Commands;
using ProductWebAPI.Application.Command;
using ProductWebAPI.Core.Entity;
using ProductWebAPI.Core.Repository;

namespace ProductWebAPI.Application.CommandHandlers;

public class CreateCategoryHandler : ICommandHandler<CreateCategory>
{
    private readonly ICategoryRepository _repository;

    public CreateCategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    public async Task HandleAsync(CreateCategory command, CancellationToken cancellationToken = new CancellationToken())
    {
        var category = new Category()
        {
            Name = command.Name
        };
        await _repository.CreateCategory(category);
    }
}