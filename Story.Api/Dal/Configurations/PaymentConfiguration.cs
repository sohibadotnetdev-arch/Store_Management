using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Store.Api.Models;

namespace Store.Api.Dal.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> entity)
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Amount)
                .HasPrecision(18, 2);

            entity.Property(p => p.Note)
                .HasMaxLength(500);

            entity.HasOne(p => p.Customer)
                .WithMany(c => c.Payments)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(p => p.Sale)
                .WithMany()
                .HasForeignKey(p => p.SaleId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    

    }
}
