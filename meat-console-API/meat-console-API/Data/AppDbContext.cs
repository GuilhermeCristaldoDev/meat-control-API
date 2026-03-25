using Microsoft.EntityFrameworkCore;
using meat_console_API.Entities;

namespace meat_console_API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Meat> Meats { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meat>(entity => {
                entity.Property(m => m.PriceKg).HasPrecision(10, 2);
                entity.Property(m => m.WeightKg).HasPrecision(10, 3);
                entity.Property(m => m.TotalPrice).HasPrecision(10, 2);
                }
            );

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(o => o.TotalAmount).HasPrecision(10, 2);
            });
           
        }
    }
}
