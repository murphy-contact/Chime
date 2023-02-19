using Chime.Modules.Users.Core.Domain.Entities;

namespace Chime.Modules.Users.Core.Repositories;

internal interface IRoleRepository
{
    Task<Role> GetAsync(string name);
    Task<IReadOnlyList<Role>> GetAllAsync();
    Task AddAsync(Role role);
}