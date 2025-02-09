using Chime.Modules.Customers.Core.Clients.UserApiClient;
using Chime.Modules.Customers.Core.Domain.Entities;
using Chime.Modules.Customers.Core.Domain.Repositories;
using Chime.Modules.Customers.Core.Exceptions;
using Chime.Shared.Abstractions.Commands;
using Chime.Shared.Abstractions.Kernel.ValueObjects;
using Chime.Shared.Abstractions.Time;
using Microsoft.Extensions.Logging;

namespace Chime.Modules.Customers.Core.Commands.CreateCustomer;

internal sealed class CreateCustomerHandler : ICommandHandler<CreateCustomer>
{
    private readonly IClock _clock;
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<CreateCustomerHandler> _logger;
    private readonly IUserApiClient _userApiClient;

    public CreateCustomerHandler(ICustomerRepository customerRepository, IClock clock,
        IUserApiClient userApiClient,
        ILogger<CreateCustomerHandler> logger)
    {
        _customerRepository = customerRepository;
        _clock = clock;
        _userApiClient = userApiClient;
        _logger = logger;
    }

    public async Task HandleAsync(CreateCustomer command, CancellationToken cancellationToken = default)
    {
        _ = new Email(command.Email);
        var user = await _userApiClient.GetUserByEmailAsync(command.Email);
        if (user is null) throw new UserNotFoundException(command.Email);

        if (user.Role is not "user") return;

        var customerId = user.UserId;
        if (await _customerRepository.GetAsync(customerId) is not null)
            throw new CustomerAlreadyExistsException(customerId);

        var customer = new Customer(customerId, command.Email, _clock.CurrentDate());
        await _customerRepository.AddAsync(customer);
        _logger.LogInformation($"Created a customer with ID: '{customer.Id}'.");
    }
}