using Chime.Modules.Users.Core.Domain.Entities;

namespace Chime.Modules.Users.Core.Queries.GetUserByEmail;

internal static class Extensions
{
    private static readonly Dictionary<UserState, string> States = new()
    {
        [UserState.Active] = UserState.Active.ToString().ToLowerInvariant(),
        [UserState.Locked] = UserState.Locked.ToString().ToLowerInvariant()
    };

    public static GetUserByEmailResponseModel AsResponseModel(this User user)
    {
        var dto = user.Map<GetUserByEmailResponseModel>();
        dto.Permissions = user.Role.Permissions;

        return dto;
    }

    private static T Map<T>(this User user) where T : GetUserByEmailResponseModel, new()
    {
        return new()
        {
            UserId = user.Id,
            Email = user.Email,
            State = States[user.State],
            Role = user.Role.Name,
            CreatedAt = user.CreatedAt
        };
    }
}