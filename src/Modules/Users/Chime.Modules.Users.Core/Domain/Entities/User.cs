using Chime.Shared.Abstractions.Kernel.ValueObjects;

namespace Chime.Modules.Users.Core.Domain.Entities;

internal class User
{
    public Guid Id { get; set; }
    public Email Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Role Role { get; set; } = null!;
    public string RoleId { get; set; } = null!;
    public UserState State { get; set; }
    public DateTime CreatedAt { get; set; }
}