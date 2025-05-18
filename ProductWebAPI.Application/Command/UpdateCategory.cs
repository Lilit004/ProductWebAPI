using Convey.CQRS.Commands;

namespace ProductWebAPI.Application.Command;

public class UpdateCategory : ICommand
{
    public long Id { get; set; }
    public string Name { get; set; }
}