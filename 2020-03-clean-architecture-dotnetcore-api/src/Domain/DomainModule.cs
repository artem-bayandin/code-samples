using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class DomainModule
    {
        public static IServiceCollection AddDomainModule(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DomainModule));

            return services;
        }
    }
}
