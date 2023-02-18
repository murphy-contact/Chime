using Chime.Modules.Customers.Core.Domain.Entities;
using Chime.Modules.Customers.Core.Domain.ValueObjects;
using Chime.Shared.Abstractions.Kernel.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chime.Modules.Customers.Core.DAL.Configurations;

internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.Email).IsRequired()
            .HasMaxLength(100)
            .HasConversion(x => x.Value, x => new Email(x));

        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired(false)
            .HasConversion(x => x.Value, x => new Name(x));

        builder.Property(x => x.FullName).HasMaxLength(100).IsRequired(false)
            .HasConversion(x => x.Value, x => new FullName(x));

        builder.Property(x => x.Address).HasMaxLength(200).IsRequired(false)
            .HasConversion(x => x.Value, x => new Address(x));

        builder.Property(x => x.Identity).HasMaxLength(40).IsRequired(false)
            .HasConversion(x => x.ToString(), x => Identity.From(x));

        builder.Property(x => x.Nationality).HasMaxLength(2).IsRequired(false)
            .HasConversion(x => x.Value, x => new Nationality(x));

        builder.Property(x => x.Notes).HasMaxLength(500).IsRequired(false);
    }
}