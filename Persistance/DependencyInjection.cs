using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Wallet_App_Backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Wallet_App_Backend.Application.Interfaces;

namespace Wallet_App_Backend.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString, options =>
                {
                    options.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                });
            });
            services.AddScoped<IApplicationDbContext>(provider =>
                provider.GetService<ApplicationDbContext>());
            return services;
        }
    }
}
