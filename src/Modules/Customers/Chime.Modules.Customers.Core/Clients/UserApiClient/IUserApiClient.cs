using Chime.Modules.Customers.Core.Clients.UserApiClient.GetUserByEmail;

namespace Chime.Modules.Customers.Core.Clients.UserApiClient;

internal interface IUserApiClient
{
    Task<GetUserByEmailResponseModel> GetUserByEmailAsync(string email);
}