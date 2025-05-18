using Convey.CQRS.Commands;
using ProductWebAPI.Application.Command;
using ProductWebAPI.Core.Repository;

namespace ProductWebAPI.Application.CommandHandlers;

public class DeleteCategoryHandler : ICommandHandler<DeleteCategory>
{
    private readonly ICategoryRepository _repository;

    public DeleteCategoryHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }
    
    public async Task HandleAsync(DeleteCategory command, CancellationToken cancellationToken = new CancellationToken())
    {
        await _repository.DeleteCategory(command.Id);
    }
}