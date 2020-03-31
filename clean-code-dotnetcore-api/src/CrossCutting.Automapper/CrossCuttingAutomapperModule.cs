using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.Automapper
{
    public static class CrossCuttingAutomapperModule
    {
        public static IServiceCollection AddCrossCuttingAutomapperModule(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CrossCuttingAutomapperModule).Assembly);

            return services;
        }
    }
}
