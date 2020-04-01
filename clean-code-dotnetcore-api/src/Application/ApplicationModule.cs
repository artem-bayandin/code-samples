using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationModule));

            services.AddAutoMapper(typeof(ApplicationModule));

            //services.AddValidatorsFromAssemblyContaining(typeof(ApplicationModule), ServiceLifetime.Scoped);

            return services;
        }
    }
}
