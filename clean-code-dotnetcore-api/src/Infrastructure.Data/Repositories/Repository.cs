using Domain.Repositories;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly ShopContext _context;

        public Repository(ShopContext context)
        {
            _context = context;
        }

        public DbSet<T> Set<T>() where T : class => _context.Set<T>();
    }
}
