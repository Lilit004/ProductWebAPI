using Convey.CQRS.Commands;

namespace ProductWebAPI.Application.Command;

public class CreateCategory : ICommand
{
    public string Name { get; set; }
}