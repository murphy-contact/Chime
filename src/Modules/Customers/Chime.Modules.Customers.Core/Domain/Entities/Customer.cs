using Chime.Modules.Customers.Core.Domain.ValueObjects;
using Chime.Modules.Customers.Core.Exceptions;
using Chime.Shared.Abstractions.Kernel.ValueObjects;

namespace Chime.Modules.Customers.Core.Domain.Entities;

internal class Customer
{
    private Customer()
    {
    }

    public Customer(Guid id, Email email, DateTime createdAt)
    {
        Id = id;
        Email = email ?? throw new InvalidCustomerEmailException(Id);
        IsActive = true;
        CreatedAt = createdAt;
    }

    public Guid Id { get; }
    public Email Email { get; }
    public Name Name { get; private set; }
    public FullName FullName { get; private set; }
    public Address Address { get; private set; }
    public Nationality Nationality { get; private set; }
    public Identity Identity { get; private set; }
    public string Notes { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; }
    public DateTime? CompletedAt { get; private set; }
    public DateTime? VerifiedAt { get; private set; }

    public void Complete(Name name, FullName fullName, Address address, Nationality nationality, Identity identity,
        DateTime completedAt)
    {
        if (!IsActive) throw new CustomerNotActiveException(Id);

        if (CompletedAt.HasValue) throw new CannotCompleteCustomerException(Id);

        Name = name ?? throw new InvalidCustomerNameException(Id);
        FullName = fullName;
        Address = address;
        Nationality = nationality;
        Identity = identity;
        CompletedAt = completedAt;
    }

    public void Verify(DateTime verifiedAt)
    {
        if (!IsActive) throw new CustomerNotActiveException(Id);

        if (!CompletedAt.HasValue || VerifiedAt.HasValue) throw new CannotVerifyCustomerException(Id);

        VerifiedAt = verifiedAt;
    }

    public void Lock(string notes = null)
    {
        IsActive = false;
        Notes = notes?.Trim();
    }

    public void Unlock(string notes = null)
    {
        IsActive = true;
        Notes = notes?.Trim();
    }
}