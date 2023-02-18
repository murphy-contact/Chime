using Chime.Modules.Customers.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chime.Modules.Customers.Core.DAL;

internal class CustomersDbContext : DbContext
{
    public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("customers");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly); // Shared Infrastructure 16
    }
}