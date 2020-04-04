using Application;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    public static class InfrastructureIocModule
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // register 'modules' (contain internal registration for automapper and mediatr)
            services.AddDomainModule();
            services.AddApplicationModule();

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

            // TODO: why this does not work?
            //ValidatorOptions.PropertyNameResolver = CamelCasePropertyNameResolver.ResolvePropertyName;

            // add automapper
            services.AddAutoMapper(typeof(DomainModule).Assembly, typeof(ApplicationModule).Assembly);

            return services;
        }
    }
}
