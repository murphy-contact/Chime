using Chime.Shared.Abstractions.Queries;

namespace Chime.Modules.Users.Core.Queries.GetUserByEmail;

internal class GetUserByEmail : IQuery<GetUserByEmailResponseModel>
{
    public string Email { get; set; }
}