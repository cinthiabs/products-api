using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Products.Commands.CreateProducts;
using Products.Application.Products.Queries.GetProducts;

namespace Products.API.Controllers.v1;

[ApiVersion("1")]
[Route("v{version:apiVersion}/products")]
public class ProductsController : ApiController
{
    [HttpPost]
    public async Task<ActionResult> CreateProductsAynsc(
       [FromServices] IMediator mediator,
       [FromBody] CreateProductsCommand command,
       CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        return ActionResult(result);
    }

    [HttpGet]
    public async Task<ActionResult<GetProductsViewModel>> GetProductsAynsc(
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetProductsQuery(), cancellationToken);
        return ActionResult(result);
    }
}