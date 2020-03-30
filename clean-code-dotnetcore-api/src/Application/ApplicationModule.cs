using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationModule).Assembly);

            services.AddAutoMapper(typeof(ApplicationModule).Assembly);

            return services;
        }
    }
}
