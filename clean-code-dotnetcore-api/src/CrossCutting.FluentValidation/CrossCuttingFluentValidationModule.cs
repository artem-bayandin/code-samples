using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.FluentValidation
{
    public static class CrossCuttingFluentValidationModule
    {
        public static IServiceCollection AddCrossCuttingFluentValidationModule(this IServiceCollection services)
        {
            // TODO: why this does not work?
            //ValidatorOptions.PropertyNameResolver = CamelCasePropertyNameResolver.ResolvePropertyName;

            return services;
        }
    }
}
