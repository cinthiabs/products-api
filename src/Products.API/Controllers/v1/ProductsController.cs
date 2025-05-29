using Microsoft.AspNetCore.Mvc;

namespace Products.API.Controllers.v1;

[ApiVersion("1")]
[Route("v{version:apiVersion}/products")]
public class ProductsController : ApiController
{
}