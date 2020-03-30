using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
