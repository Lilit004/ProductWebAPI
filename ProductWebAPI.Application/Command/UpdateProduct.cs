using Convey.CQRS.Commands;

namespace ProductWebAPI.Application.Command;

public class UpdateProduct : ICommand
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<int> CategoryIds { get; set; }
}