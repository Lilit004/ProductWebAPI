using Convey.CQRS.Commands;
using ProductWebAPI.Application.Command;
using ProductWebAPI.Core.Entity;
using ProductWebAPI.Core.Repository;

namespace ProductWebAPI.Application.CommandHandlers;

public class UpdateCategoryHandler : ICommandHandler<UpdateCategory>
{
    private readonly ICategoryRepository _repository;

    public UpdateCategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    
    public async Task HandleAsync(UpdateCategory command, CancellationToken cancellationToken = new CancellationToken())
    {
        var category = new Category()
        {
            Id = command.Id,
            Name = command.Name
        };
        await _repository.UpdateCategory(category);
    }
}