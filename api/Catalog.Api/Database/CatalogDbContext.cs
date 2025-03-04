using System;
using System.Linq;
using Catalog.Api.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Database;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<CatalogItemDto> Items { get; set; }
    public DbSet<CatalogCategoryDto> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<CatalogItemDto>().HasKey(m => m.Id);
        builder.Entity<CatalogCategoryDto>().HasKey(m => m.Id);
        builder.Entity<CatalogItemDto>().Property<DateTime>("UpdatedTime");
        builder.Entity<CatalogCategoryDto>().Property<DateTime>("UpdatedTime");

        base.OnModelCreating(builder);
    }

    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();
        updateUpdatedProperty<CatalogItemDto>();
        updateUpdatedProperty<CatalogCategoryDto>();
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