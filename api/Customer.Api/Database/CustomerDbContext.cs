using System;
using System.Linq;
using CustomerService.Api.Database.Models;
using CustomerService.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CustomerService.Api.Database
{
    public class CustomerDbContext : DbContext
    {
        private readonly IOptions<DatabaseOptions> _dbOptions;
        private readonly ISeedDataProvider<CustomerDto> _seedDataProvider;

        public CustomerDbContext(DbContextOptions options, 
            IOptions<DatabaseOptions> dbOptions,
            ISeedDataProvider<CustomerDto> seedDataProvider) : base(options)
        {
            _dbOptions = dbOptions;
            _seedDataProvider = seedDataProvider;
        }

        public DbSet<CustomerDto> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomerDto>().HasKey(m => m.Id);
            
            if (_dbOptions.Value.EnableSeedData)
            {
                foreach (var customer in _seedDataProvider.GetSeedData())
                {
                    builder.Entity<CustomerDto>().HasData(customer);
                }
            }

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
}