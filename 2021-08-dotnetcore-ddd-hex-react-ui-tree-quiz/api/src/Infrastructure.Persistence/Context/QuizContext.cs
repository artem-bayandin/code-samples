using Domain.Ports.Out;
using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
    public interface IQuizContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Quiz> Quizzes { get; set; }
        DbSet<QuizUserAnswer> Answers { get; set; }
    }

    public class QuizContext : DbContext, IQuizContext, IUnitOfWork
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<QuizUserAnswer> Answers { get; set; }

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
