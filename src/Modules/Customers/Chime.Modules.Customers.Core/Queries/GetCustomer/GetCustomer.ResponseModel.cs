using Chime.Modules.Customers.Core.Domain.Entities;

namespace Chime.Modules.Customers.Core.Queries.GetCustomer;

internal static class GetCustomerResponseModel
{
    public static CustomerDto AsDto(this Customer customer)
    {
        return customer.Map<CustomerDto>();
    }

    public static CustomerDetailsDto? AsResponseModel(this Customer customer)
    {
        var dto = customer.Map<CustomerDetailsDto>();
        dto.Address = customer.Address;
        dto.Identity = customer.Identity is null
            ? null
            : new IdentityDto
            {
                Type = customer.Identity.Type,
                Series = customer.Identity.Series
            };
        dto.Notes = customer.Notes;

        return dto;
    }

    private static T Map<T>(this Customer customer) where T : CustomerDto, new()
    {
        return new T
        {
            CustomerId = customer.Id,
            Email = customer.Email,
            Name = customer.Name,
            FullName = customer.FullName,
            Nationality = customer.Nationality,
            IsActive = customer.IsActive,
            CreatedAt = customer.CreatedAt
        };
    }
}