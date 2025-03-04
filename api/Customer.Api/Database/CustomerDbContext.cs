using System;
using System.Linq;
using Customer.Api.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer.Api.Database;

public class CustomerDbContext : DbContext
{
    public CustomerDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<CustomerDto> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<CustomerDto>().HasKey(m => m.Id);
        builder.Entity<CustomerDto>().Property<DateTime>("UpdatedTime");
        base.OnModelCreating(builder);
    }

    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();
        updateUpdatedProperty<CustomerDto>();

        return base.SaveChanges();
    }

    private void updateUpdatedProperty<T>() where T : class
    {
        var modifiedSourceInfo =
            ChangeTracker.Entries<T>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entry in modifiedSourceInfo)
            entry.Property("UpdatedTime").CurrentValue = DateTime.UtcNow;
    }
}