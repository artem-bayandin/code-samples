using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Seeds
{
    public class ProductCategorySeed : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder
                .HasData(
                    ProductCategory.Create("Notebook"),
                    ProductCategory.Create("PC"),
                    ProductCategory.Create("Input device")
                );
        }
    }
}
