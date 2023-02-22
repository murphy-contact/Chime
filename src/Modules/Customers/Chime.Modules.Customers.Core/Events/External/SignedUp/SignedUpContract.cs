using Chime.Shared.Abstractions.Contracts;

namespace Chime.Modules.Customers.Core.Events.External.SignedUp;

internal class SignedUpContract : Contract<SignedUp>
{
    public SignedUpContract() //"users")
    {
        RequireAll();
    }
}