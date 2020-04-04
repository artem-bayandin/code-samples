using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    // TODO: remove EF ref
    public interface IShopContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductCategory> ProductCategories { get; set; }
        DbSet<ProductLineItem> ProductLineItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
