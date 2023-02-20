using Chime.Modules.Users.Core.DAL;
using Chime.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Chime.Modules.Users.Core.Queries.GetUserByEmail;

internal sealed class GetUserByEmailHandler : IQueryHandler<GetUserByEmail, GetUserByEmailResponseModel>
{
    private readonly UsersDbContext _dbContext;

    public GetUserByEmailHandler(UsersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetUserByEmailResponseModel> HandleAsync(GetUserByEmail query,
        CancellationToken cancellationToken = default)
    {
        var user = await _dbContext.Users
            .AsNoTracking()
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Email == query.Email, cancellationToken);

        return user?.AsResponseModel();
    }
}