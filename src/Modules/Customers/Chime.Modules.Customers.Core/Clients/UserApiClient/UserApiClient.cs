using Chime.Modules.Customers.Core.Clients.UserApiClient.GetUserByEmail;
using Chime.Shared.Abstractions.Modules;

namespace Chime.Modules.Customers.Core.Clients.UserApiClient;

internal class UserApiClient : IUserApiClient
{
    private readonly IModuleClient _moduleClient;

    public UserApiClient(IModuleClient moduleClient)
    {
        _moduleClient = moduleClient;
    }

    public Task<GetUserByEmailResponseModel> GetUserByEmailAsync(string email)
    {
        return _moduleClient.SendAsync<GetUserByEmailResponseModel>("users/get-by-email", new { email });
    }
}