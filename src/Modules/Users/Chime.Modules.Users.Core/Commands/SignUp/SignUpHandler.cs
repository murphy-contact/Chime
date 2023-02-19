using Chime.Modules.Users.Core.Domain.Entities;
using Chime.Modules.Users.Core.Repositories;
using Chime.Shared.Abstractions.Commands;
using Chime.Shared.Abstractions.Time;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Chime.Modules.Users.Core.Commands.SignUp;

internal sealed class SignUpHandler : ICommandHandler<SignUp>
{
    private readonly IClock _clock;
    private readonly ILogger<SignUpHandler> _logger;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;

    public SignUpHandler(
        // IUserRepository userRepository, 
        // IRoleRepository roleRepository,
        // IPasswordHasher<User> passwordHasher, 
        // IClock clock,
        //IMessageBroker messageBroker,
        // RegistrationOptions registrationOptions, 
        // ILogger<SignUpHandler> logger
        )
    {
        // _userRepository = userRepository;
        // _roleRepository = roleRepository;
        // _clock = clock;
        // _logger = logger;
    }

    public Task HandleAsync(SignUp command, CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}