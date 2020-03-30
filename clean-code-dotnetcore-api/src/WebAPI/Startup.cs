using System.Reflection;
using Application;
using Application.Queries;
using AutoMapper;
using Infrastructure.Data.Contexts;
using MediatR;
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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // add services
            services.AddDbContext<ShopContext>(options => 
                options.UseSqlServer(
                    Configuration.GetConnectionString("EntitiesDatabase"),
                    // enable auto migrations
                    optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(ShopContext).GetTypeInfo().Assembly.GetName().Name)
                )
            );

            services.AddApplicationModule();

            //services.AddElmah<SqlErrorLog>(options =>
            //{
            //    options.Path = @"/elmah";
            //    //options.CheckPermissionAction = context => context.User.Identity.IsAuthenticated; // todo: check if user HasWritePermissions
            //    options.ConnectionString = Configuration.GetConnectionString("EventLogDatabase"); // todo: DB structure see here: https://bitbucket.org/project-elmah/main/downloads/ELMAH-1.2-db-SQLServer.sql
            //    // options.Notifiers.Add(new ErrorMailNotifier("Email", new EmailOptions()));
            //});

            //services.AddMvc(options =>
            //{
            //    options.OutputFormatters.Add(new JsonOutputFormatter(
            //        Microsoft.AspNetCore.Mvc.Formatters.JsonSerializerSettingsProvider.CreateSerializerSettings(), ArrayPool<Char>.Shared));

            //    if (!CurrentEnvironment.IsProduction() && !Configuration.GetValue<bool>("UseAuthentication"))
            //    {
            //        options.Filters.Add(new AllowAnonymousFilter());
            //    }
            //})
            //    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddHttpContextAccessor();

           // services.AddAuthorization(options =>
           // {
           //     options.AddPolicy(AuthorizationPoliciesConstants.AzureAuthorizationPoliciesName, policy =>
           //         policy.Requirements.Add(new AzureRequirement()));
           // });

           // services.AddAuthentication(sharedOptions =>
           // {
           //     sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
           // })
           //.AddAzureAdBearer(options => Configuration.Bind(AuthorizationPoliciesConstants.AzureAuthorizationOptionsName, options));

           // // In production, the React files will be served from this directory
           // services.AddSpaStaticFiles(configuration =>
           // {
           //     configuration.RootPath = "ClientApp/build";
           // });

            // Adding MediatR for Domain Events and Notifications
            //services.AddMediatR(typeof(Startup));
            services.AddMediatR(typeof(ProductCategoriesQuery).GetTypeInfo().Assembly);

            // automapper
            services.AddAutoMapper(typeof(ProductCategoriesQuery).GetTypeInfo().Assembly);

            // add cors for development
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAll",
            //        builder =>
            //        {
            //            builder.AllowAnyOrigin();
            //            builder.AllowAnyHeader();
            //            builder.AllowAnyMethod();
            //        });
            //});

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
