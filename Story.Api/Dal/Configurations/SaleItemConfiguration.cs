using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Store.Api.Models;

namespace Store.Api.Dal.Configurations
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> entity)
        {
            entity.HasKey(si => si.Id);

            entity.Property(si => si.Qty)
                .IsRequired();

            entity.Property(si => si.UnitPrice)
                .HasPrecision(18, 2);

            entity.Property(si => si.TotalPrice)
                .HasPrecision(18, 2);

            entity.HasOne(si => si.Product)
                .WithMany()
                .HasForeignKey(si => si.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    
    }
}
