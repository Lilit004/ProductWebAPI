using Convey.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ProductWebAPI.Application.Command;

public class DeleteCategory : ICommand
{
    [FromRoute (Name = "id")]
    public long Id { get; set; }
}