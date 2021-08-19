using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings
{
    public class ProductLineItemMap : IEntityTypeConfiguration<ProductLineItem>
    {
        public void Configure(EntityTypeBuilder<ProductLineItem> builder)
        {
            builder.HasKey(x => new { x.OrderId, x.ProductId });

            builder.HasOne(x => x.Order)
                .WithMany(x => x.ProductLineItems)
                .HasForeignKey(x => x.OrderId);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductLineItems)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
