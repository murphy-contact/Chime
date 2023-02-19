namespace Chime.Modules.Users.Core.Domain.Entities;

internal class Role
{
    public const string User = "user";
    public const string Admin = "admin";

    public string Name { get; set; } = null!;
    public IEnumerable<string> Permissions { get; set; } = null!;
    public IEnumerable<User> Users { get; set; } = null!;

    public static string Default => User;
}