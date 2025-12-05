using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Store.Api.Models;

namespace Store.Api.Dal.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> entity)
        {
            entity.HasKey(s => s.Id);

            entity.Property(s => s.TotalAmount)
                .HasPrecision(18, 2);

            entity.Property(s => s.PaidAmount)
                .HasPrecision(18, 2);

            entity.Property(s => s.DebtAmount)
                .HasPrecision(18, 2);

            entity.Property(s => s.PaymentMethod)
                .HasMaxLength(20);

            entity.Property(s => s.Note)
                .HasMaxLength(500);

            entity.HasMany(s => s.Items)
                .WithOne(si => si.Sale)
                .HasForeignKey(si => si.SaleId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(s => s.Customer)
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    

    }
}
