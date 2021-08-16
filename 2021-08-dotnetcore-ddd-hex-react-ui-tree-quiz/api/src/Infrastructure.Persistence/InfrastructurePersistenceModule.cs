using Domain.Ports.Out;
using Infrastructure.Persistence.Adapters;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public static class InfrastructurePersistenceModule
    {
        public static IServiceCollection RegisterInfrastructurePersistenceModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IQuizPortOut, QuizPortOut>();
            services.AddScoped<IUserPortOut, UserPortOut>();

            // add database
            services
                .AddDbContext<QuizContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("Db"),
                    // enable auto migrations
                    optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(QuizContext).Assembly.GetName().Name)
                )
            );

            // register context
            services.AddScoped<IQuizContext>(provider => provider.GetService<QuizContext>());
            // register UoF
            services.AddScoped<IUnitOfWork>(provider => provider.GetService<QuizContext>());

            return services;
        }
    }
}
