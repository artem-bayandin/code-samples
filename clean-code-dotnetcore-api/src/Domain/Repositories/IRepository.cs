using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public interface IRepository
    {
        // TODO: remove reference to EF
        DbSet<T> Set<T>() where T : class;
    }
}
