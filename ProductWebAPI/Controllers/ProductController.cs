using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.Application.Command;
using ProductWebAPI.Application.Query;

namespace ProductWebAPI.Controllers;

[Route("products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public ProductController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost("add")]
    public async Task<IActionResult> CreateProduct(CreateProduct command)
    {
        await _commandDispatcher.SendAsync(command);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById([FromRoute] GetProductById query)
    {
        var productDto = await _queryDispatcher.QueryAsync(query);
        return Ok(productDto);
    }
    
    [HttpGet("")]
    public async Task<IActionResult> GetProducts([FromQuery] GetProducts query)
    {
        var productDtos = await _queryDispatcher.QueryAsync(query);
        return Ok(productDtos);
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> UpdateProduct(UpdateProduct command)
    {
        await _commandDispatcher.SendAsync(command);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] DeleteProduct command)
    {
        await _commandDispatcher.SendAsync(command);
        return Ok();
    }
}