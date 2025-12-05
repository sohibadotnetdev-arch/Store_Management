using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Store.Api.Models;

namespace Store.Api.Dal.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(c => c.Phone)
                .HasMaxLength(50);

            entity.Property(c => c.Address)
                .HasMaxLength(500);

            entity.Property(c => c.TotalDebt)
                .HasPrecision(18, 2);

            entity.HasMany(c => c.Sales)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerId);

            entity.HasMany(c => c.Payments)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId);
        }
    
    }
}
