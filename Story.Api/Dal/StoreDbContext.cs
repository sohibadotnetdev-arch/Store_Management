using Microsoft.EntityFrameworkCore;
using Store.Api.Models;

namespace Store.Api.Dal
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<SaleItem> SaleItem { get; set; }
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);

        }



    }
}
