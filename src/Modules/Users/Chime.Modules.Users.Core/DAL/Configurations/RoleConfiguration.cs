using Chime.Modules.Users.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chime.Modules.Users.Core.DAL.Configurations;

internal class RoleConfiguration
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Name);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder
            .Property(x => x.Permissions)
            .HasConversion(x => string.Join(',', x), x => x.Split(',', StringSplitOptions.None));
            
        builder
            .Property(x => x.Permissions).Metadata.SetValueComparer(
                new ValueComparer<IEnumerable<string>>(
                    (c1, c2) => c1!.SequenceEqual(c2!),
                    c => c.Aggregate(0, (a, next) => HashCode.Combine(a, next.GetHashCode()))));
    }
}