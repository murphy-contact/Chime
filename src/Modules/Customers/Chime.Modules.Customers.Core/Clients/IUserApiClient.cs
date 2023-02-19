using Chime.Modules.Customers.Core.Clients.DTO;

namespace Chime.Modules.Customers.Core.Clients;

internal interface IUserApiClient
{
    Task<UserDto> GetAsync(string email);
}