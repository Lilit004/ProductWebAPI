using Convey.CQRS.Commands;

namespace ProductWebAPI.Application.Command;

public class CreateProduct : ICommand
{
    public string Name { get; set; }
    public List<int> CategoryIds { get; set; }
}