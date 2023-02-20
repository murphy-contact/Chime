namespace Chime.Modules.Users.Core.Queries.GetUserByEmail;

public class GetUserByEmailResponseModel
{
    public Guid UserId { get; set; }
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string State { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public IEnumerable<string> Permissions { get; set; } = null!;
}