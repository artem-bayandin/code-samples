using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
    public interface IQuizContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Quiz> Quizzes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }

    public class QuizContext : DbContext, IQuizContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Quiz> Quizzes { get; set; }

        public QuizContext(DbContextOptions<QuizContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuizContext).Assembly);

            //modelBuilder.TypeDateTimeToDatetime2();
            //modelBuilder.TypeStringToNvarchar255();
            //modelBuilder.RemovePluralizingTableNameConvention();
            //modelBuilder.SetOnDeleteBehaviorToRestrict();

            base.OnModelCreating(modelBuilder);
        }
    }
}
