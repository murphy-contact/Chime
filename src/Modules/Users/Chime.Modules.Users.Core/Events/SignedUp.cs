using Chime.Shared.Abstractions.Events;

namespace Chime.Modules.Users.Core.Events;

internal record SignedUp(Guid UserId, string Email, string Role) : IEvent;