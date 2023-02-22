using Chime.Shared.Abstractions.Contracts;
using Chime.Shared.Abstractions.Messaging;

namespace Chime.Modules.Customers.Core.Events.External.SignedUp;

[Message("users")]
internal class SignedUpContract : Contract<SignedUp>
{
    public SignedUpContract()
    {
        RequireAll();
    }
}