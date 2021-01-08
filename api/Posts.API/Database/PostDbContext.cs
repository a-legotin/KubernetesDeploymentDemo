using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Posts.API
{
    public class PostDbContextDbContext : DbContext
    {
        public PostDbContextDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PostDto> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PostDto>().HasKey(m => m.Id);
            builder.Entity<PostDto>().Property<DateTime>("UpdatedTime");

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            updateUpdatedProperty<PostDto>();
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