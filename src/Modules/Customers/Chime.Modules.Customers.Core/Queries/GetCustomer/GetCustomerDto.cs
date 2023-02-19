namespace Chime.Modules.Customers.Core.Queries.GetCustomer;

internal class CustomerDetailsDto : CustomerDto
{
    public string Address { get; set; } = null!;
    public IdentityDto Identity { get; set; } = null!;
    public string Notes { get; set; } = null!;
}

internal class IdentityDto
{
    public string Type { get; set; } = null!;
    public string Series { get; set; } = null!;
}

internal class CustomerDto
{
    public Guid CustomerId { get; set; }

    public string State { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Nationality { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}