namespace Chime.Modules.Customers.Core.Queries.GetCustomer;

internal class CustomerDetailsDto : CustomerDto
{
    public string Address { get; set; }
    public IdentityDto Identity { get; set; }
    public string Notes { get; set; }
}

internal class IdentityDto
{
    public string Type { get; set; }
    public string Series { get; set; }
}

internal class CustomerDto
{
    public Guid CustomerId { get; set; }
    
    public string State { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string FullName { get; set; }
    public string Nationality { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}