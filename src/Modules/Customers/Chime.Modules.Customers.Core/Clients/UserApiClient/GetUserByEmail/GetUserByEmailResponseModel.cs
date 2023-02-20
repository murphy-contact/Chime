namespace Chime.Modules.Customers.Core.Clients.UserApiClient.GetUserByEmail;

internal class GetUserByEmailResponseModel
{
    public Guid UserId { get; set; }
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
}