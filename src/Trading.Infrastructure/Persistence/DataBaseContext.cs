using Microsoft.EntityFrameworkCore;
using Trading.Domain.Common;
using Trading.Domain.Entities;

namespace Trading.Infrastructure.Persistence
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the primary key and auto-increment
            modelBuilder.Entity<Position>()
                .HasKey(p => p.TransactionId); // Ensure Id is the primary key

            modelBuilder.Entity<Position>()
                .Property(p => p.TransactionId)
                .ValueGeneratedOnAdd(); // This ensures the Id is auto-incremented
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "System";
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.Now;
                        entry.Entity.ModifiedBy = "System";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
