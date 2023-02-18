using Chime.Modules.Customers.Core.Commands;
using Chime.Modules.Customers.Core.Queries.GetCustomer;
using Chime.Shared.Abstractions.Dispatchers;
using Microsoft.AspNetCore.Mvc;

namespace Chime.Modules.Customers.Api.Controllers;

[ApiController]
[Route("[controller]")]
internal class CustomersController : Controller
{
    private readonly IDispatcher _dispatcher;

    public CustomersController(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpGet("{customerId:guid}")]
    public async Task<ActionResult<CustomerDetailsDto>> Get(Guid customerId)
    {
        var customer = await _dispatcher.QueryAsync(new GetCustomer { CustomerId = customerId });

        if (customer is not null) return Ok(customer);

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync(CreateCustomer command)
    {
        await _dispatcher.SendAsync(command);
        return NoContent();
    }
}