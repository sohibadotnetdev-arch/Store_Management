using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Api.Models;

namespace Store.Api.Dal.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(p => p.SKU)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(p => p.Unit)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(p => p.Barcode)
                .HasMaxLength(50);

            entity.Property(p => p.BuyPrice)
                .HasPrecision(18, 2);

            entity.Property(p => p.SellPrice)
                .HasPrecision(18, 2);

            entity.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            entity.Property(p => p.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            entity.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
