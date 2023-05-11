using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Wallet_App_Backend.Application.Common.Behaviors;
using Wallet_App_Backend.Application.Core.Services;
using Wallet_App_Backend.Application.Interfaces;

namespace Wallet_App_Backend.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            services
                .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

            services.AddScoped<ISeasonsHelper, SeasonsHelper>();


            return services;
        }
    }
}
