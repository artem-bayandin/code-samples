using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.Seeds
{
    public class ProductCategorySeed : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder
                .HasData(
                    new ProductCategory
                    {
                        Id = Guid.NewGuid(),
                        Name = "Notebook"
                    },
                    new ProductCategory
                    {
                        Id = Guid.NewGuid(),
                        Name = "PC"
                    },
                    new ProductCategory
                    {
                        Id = Guid.NewGuid(),
                        Name = "Input device"
                    }
                );
        }
    }
}
