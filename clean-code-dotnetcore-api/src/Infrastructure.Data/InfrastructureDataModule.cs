using Domain.Interfaces;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data
{
    public static class InfrastructureDataModule
    {
        public static IServiceCollection AddInfrastructureDataModule(this IServiceCollection services, IConfiguration configuration)
        {
            // add database
            services
                .AddDbContext<ShopContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("EntitiesDatabase"),
                    // enable auto migrations
                    optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(ShopContext).Assembly.GetName().Name)
                )
            );

            // register context
            services.AddScoped<IShopContext>(provider => provider.GetService<ShopContext>());

            return services;
        }
    }
}
