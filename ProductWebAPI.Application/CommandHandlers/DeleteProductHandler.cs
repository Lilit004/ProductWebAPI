using Convey.CQRS.Commands;
using ProductWebAPI.Application.Command;
using ProductWebAPI.Core.Repository;

namespace ProductWebAPI.Application.CommandHandlers;

public class DeleteProductHandler : ICommandHandler<DeleteProduct>
{
    private readonly IProductRepository _repository;

    public DeleteProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    
    public async Task HandleAsync(DeleteProduct command, CancellationToken cancellationToken = new CancellationToken())
    {
        await _repository.DeleteProduct(command.Id);
    }
}