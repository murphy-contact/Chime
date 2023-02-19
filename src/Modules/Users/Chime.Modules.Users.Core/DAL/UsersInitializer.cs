using Chime.Modules.Users.Core.Domain.Entities;
using Chime.Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Chime.Modules.Users.Core.DAL;

internal class UsersInitializer : IInitializer
{
    private readonly UsersDbContext _dbContext;
    private readonly ILogger<UsersInitializer> _logger;

    private readonly HashSet<string> _permissions = new()
    {
        "customers",
        "deposits", "withdrawals",
        "users",
        "transfers", "wallets"
    };

    public UsersInitializer(UsersDbContext dbContext, ILogger<UsersInitializer> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task InitAsync()
    {
        if (await _dbContext.Roles.AnyAsync()) return;

        await AddRolesAsync();
        await _dbContext.SaveChangesAsync();
    }

    private async Task AddRolesAsync()
    {
        await _dbContext.Roles.AddAsync(new Role
        {
            Name = "admin",
            Permissions = _permissions
        });
        await _dbContext.Roles.AddAsync(new Role
        {
            Name = "user",
            Permissions = new List<string>()
        });

        _logger.LogInformation("Initialized roles.");
    }
}