using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.Application.Command;
using ProductWebAPI.Application.Query;
using ProductWebAPI.Core.Entity;

namespace ProductWebAPI.Controllers;

[Route("categories")]
[ApiController]

public class CategoryController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public CategoryController(ICommandDispatcher commandDispatcher,IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpPost("add")]
    public async Task<IActionResult> CreateCategory(CreateCategory command)
    {
        await _commandDispatcher.SendAsync(command);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById([FromRoute] GetCategoryById query)
    {
        var category = await _queryDispatcher.QueryAsync(query);
        return Ok(category);
    }

    [HttpGet("")]
    public async Task<IActionResult> GetCategories([FromQuery] GetCategories query)
    {
        var categories = await _queryDispatcher.QueryAsync(query);
        return Ok(categories);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateCategory(UpdateCategory command)
    {
        await _commandDispatcher.SendAsync(command);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] DeleteCategory command)
    {
        await _commandDispatcher.SendAsync(command);
        return Ok();
    }
}