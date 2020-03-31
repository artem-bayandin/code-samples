using Application;
using Domain;
using Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // add database
            services
                .AddDbContext<ShopContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("EntitiesDatabase"),
                    // enable auto migrations
                    optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(ShopContext).Assembly.GetName().Name)
                )
            );

            // register 'modules' (contain internal registration for automapper and mediatr)
            services.AddApplicationModule();
            services.AddDomainModule();

            // TODO: what is it for?
            services.AddHttpContextAccessor();

            // TODO: what is it for?
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    
}
