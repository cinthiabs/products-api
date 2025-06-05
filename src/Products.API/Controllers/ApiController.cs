using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;

namespace Products.API.Controllers;

[ApiController]
[Produces("application/json")]
public abstract class ApiController : ControllerBase
{
    protected ActionResult ActionResult<T>(Result<T> result)
    {
        if (result == null)
            return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");

        return result.Status switch
        {
            ResultStatus.Ok => Ok(result.Value),
            ResultStatus.NotFound => NotFound(result.Errors),
            ResultStatus.Invalid => BadRequest(result.ValidationErrors),
            ResultStatus.Unauthorized => Unauthorized(result.Errors),
            ResultStatus.Conflict => Conflict(result.Errors),
            ResultStatus.Forbidden => Forbid(),
            ResultStatus.Error => StatusCode(StatusCodes.Status500InternalServerError, result.Errors),
            _ => StatusCode(StatusCodes.Status500InternalServerError, "Unknown error occurred.")
        };
    }
}
