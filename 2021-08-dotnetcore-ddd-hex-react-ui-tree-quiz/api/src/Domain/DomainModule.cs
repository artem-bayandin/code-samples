using Domain.Ports.In;
using Domain.PortsImplementation.Quiz;
using Domain.PortsImplementation.User;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Domain
{
    public static class DomainModule
    {
        public static IServiceCollection RegisterDomainModule(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DomainModule));
            services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(DomainModule)));

            services.AddScoped<IQuizPortIn, QuizPortIn>();
            services.AddScoped<IUserPortIn, UserPortIn>();

            return services;
        }
    }
}
