using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Products.Commands.CreateProducts;
using Products.Application.Products.Commands.RemoveProducts;
using Products.Application.Products.Queries.GetProducts;

namespace Products.API.Controllers.v1;

[ApiVersion("1")]
[Route("v{version:apiVersion}/products")]
public class ProductsController : ApiController
{
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> CreateProductsAynsc(
       [FromServices] IMediator mediator,
       [FromBody] CreateProductsCommand command,
       CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        return ActionResult(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetAllProductsViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<GetAllProductsViewModel>> GetProductsAynsc(
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllProductsQuery(), cancellationToken);
        return ActionResult(result);
    }

    [HttpDelete("{Id}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> RemoveProductsAynsc(
       [FromServices] IMediator mediator,
       [FromRoute] RemoveProductsCommand command,
       CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        return ActionResult(result);
    }

}