using Chime.Modules.Customers.Core.Commands;
using Chime.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Chime.Bootstrapper.Controllers;

[ApiController]
[Route("[controller]")]
internal class CustomersController : Controller
{
    private readonly ICommandDispatcher _commandDispatcher;

    public CustomersController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync(CreateCustomer command)
    {
        await _commandDispatcher.SendAsync(command);
        return NoContent();
    }
}