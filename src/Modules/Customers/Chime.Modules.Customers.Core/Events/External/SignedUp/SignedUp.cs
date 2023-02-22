using Chime.Shared.Abstractions.Events;

namespace Chime.Modules.Customers.Core.Events.External.SignedUp;

internal record SignedUp(Guid UserId, string Email, string Role) : IEvent;