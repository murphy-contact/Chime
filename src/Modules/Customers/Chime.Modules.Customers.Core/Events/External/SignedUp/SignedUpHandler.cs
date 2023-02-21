using Chime.Modules.Customers.Core.Domain.Entities;
using Chime.Modules.Customers.Core.Domain.Repositories;
using Chime.Shared.Abstractions.Events;
using Chime.Shared.Abstractions.Time;
using Microsoft.Extensions.Logging;

namespace Chime.Modules.Customers.Core.Events.External.SignedUp;

internal sealed class SignedUpHandler : IEventHandler<SignedUp>
{
    private const string ValidRole = "user";

    // private readonly IMessageBroker _messageBroker;
    private readonly IClock _clock;
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<SignedUpHandler> _logger;

    public SignedUpHandler(ICustomerRepository customerRepository,
        // IMessageBroker messageBroker
        IClock clock,
        ILogger<SignedUpHandler> logger)
    {
        _customerRepository = customerRepository;
        // _messageBroker = messageBroker;
        _clock = clock;
        _logger = logger;
    }

    public async Task HandleAsync(SignedUp @event, CancellationToken cancellationToken = default)
    {
        await Task.Delay(10000);
        throw new Exception("ouch");

        if (@event.Role is not ValidRole) return;

        var customer = new Customer(@event.UserId, @event.Email, _clock.CurrentDate());
        await _customerRepository.AddAsync(customer);
        _logger.LogInformation($"Created a new customer based on user with ID: '{@event.UserId}'.");
        // await _messageBroker.PublishAsync(new CustomerCreated(customer.Id), cancellationToken);
    }
}