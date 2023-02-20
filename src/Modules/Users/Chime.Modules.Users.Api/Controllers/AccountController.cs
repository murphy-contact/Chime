using Chime.Modules.Users.Core.Commands.SignUp;
using Chime.Shared.Abstractions.Contexts;
using Chime.Shared.Abstractions.Dispatchers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Chime.Modules.Users.Api.Controllers;

internal class AccountController : BaseController
{
    private const string AccessTokenCookie = "__access-token";

    private readonly IContext _context;

    // private readonly IUserRequestStorage _userRequestStorage;
    // private readonly CookieOptions _cookieOptions;
    private readonly IDispatcher _dispatcher;

    public AccountController(IDispatcher dispatcher, IContext context
        // IUserRequestStorage userRequestStorage,
        // CookieOptions cookieOptions
    )
    {
        _dispatcher = dispatcher;
        _context = context;
        // _userRequestStorage = userRequestStorage;
        // _cookieOptions = cookieOptions;
    }

    [HttpGet]
    [Authorize]
    [SwaggerOperation("Get account")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> GetAsync()
    {
        return Ok();
    }

    [HttpPost("sign-up")]
    [SwaggerOperation("Sign up")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> SignUpAsync(SignUp command)
    {
        await _dispatcher.SendAsync(command);
        return NoContent();
    }

    [HttpPost("sign-in")]
    [SwaggerOperation("Sign in")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> SignInAsync()
    {
        return Ok();
    }

    [Authorize]
    [HttpDelete("sign-out")]
    [SwaggerOperation("Sign out")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> SignOutAsync()
    {
        return NoContent();
    }
}