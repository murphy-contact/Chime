using System.ComponentModel.DataAnnotations;
using Chime.Shared.Abstractions.Commands;

namespace Chime.Modules.Users.Core.Commands.SignUp;

internal record SignUp([Required] [EmailAddress] string Email, [Required] string Password, string Role) : ICommand
{
    public Guid UserId { get; init; } = Guid.NewGuid();
}