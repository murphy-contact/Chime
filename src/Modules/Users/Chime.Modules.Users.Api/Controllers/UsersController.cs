using Chime.Shared.Abstractions.Dispatchers;
using Microsoft.AspNetCore.Authorization;

namespace Chime.Modules.Users.Api.Controllers;

[Authorize(Policy)]
internal class UsersController : BaseController
{
    private const string Policy = "users";
    private readonly IDispatcher _dispatcher;

    public UsersController(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }
}