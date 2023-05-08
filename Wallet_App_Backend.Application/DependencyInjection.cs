using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Wallet_App_Backend.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services
                .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

            return services;
        }
    }
}
