using Application;
using Domain;
using Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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

            // TODO: read docs
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    Configuration.GetValue<string>("Swagger:Version")
                    , new OpenApiInfo {
                        Title = Configuration.GetValue<string>("Swagger:Title")
                        , Version = Configuration.GetValue<string>("Swagger:Version")
                    });
            });
            // System.Text.Json (STJ) vs Newtonsoft
            // Install-Package Swashbuckle.AspNetCore.Newtonsoft -Version 5.2.1
            // link: https://github.com/domaindrivendev/Swashbuckle.AspNetCore
            services.AddSwaggerGenNewtonsoftSupport();
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

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(
                    Configuration.GetValue<string>("Swagger:JsonEndpoint")
                    , $"{Configuration.GetValue<string>("Swagger:Title")} {Configuration.GetValue<string>("Swagger:Version")}"
                );
            });
        }
    }

    
}
