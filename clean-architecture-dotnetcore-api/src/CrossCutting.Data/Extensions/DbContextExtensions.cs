using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Linq;

namespace CrossCutting.Data.Extensions
{
    public static class DbContextExtensions
    {
        public static ModelBuilder TypeDateTimeToDatetime2(this ModelBuilder modelBuilder)
        {
            var propsQuery = modelBuilder
                .Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties());

            foreach (var property in propsQuery.Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?)))
            {
                string colType = property.GetColumnType();
                if (String.IsNullOrEmpty(colType))
                {
                    property.SetColumnType("datetime2");
                }
            }

            return modelBuilder;
        }

        public static ModelBuilder TypeStringToNvarchar255(this ModelBuilder modelBuilder)
        {
            var propsQuery = modelBuilder
                .Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties());

            foreach (var property in propsQuery.Where(p => p.ClrType == typeof(String)))
            {
                string colType = property.GetColumnType();
                if (String.IsNullOrEmpty(colType))
                {
                    property.SetColumnType("nvarchar(255)");
                }
            }

            return modelBuilder;
        }

        public static ModelBuilder RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }

            return modelBuilder;
        }

        public static ModelBuilder SetOnDeleteBehaviorToRestrict(this ModelBuilder modelBuilder)
        {
            foreach (IMutableForeignKey relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            return modelBuilder;
        }
    }
}
