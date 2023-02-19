using Chime.Shared.Infrastructure.API;
using Microsoft.AspNetCore.Mvc;

namespace Chime.Modules.Users.Api.Controllers;

[ApiController]
[Route("[controller]")]
[ProducesDefaultContentType]
internal abstract class BaseController : ControllerBase
{
    protected ActionResult<T> OkOrNotFound<T>(T model)
    {
        if (model is not null) return Ok(model);

        return NotFound();
    }
}