using System.Reflection;
using Wallet_App_Backend.API.Middleware;
using Wallet_App_Backend.Application;
using Wallet_App_Backend.Application.Common.Mappings;
using Wallet_App_Backend.Application.Interfaces;
using Wallet_App_Backend.Infrastructure;
using Wallet_App_Backend.Infrastructure.Persistence;

internal class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddApplication(builder.Configuration);
        builder.Services.AddPersistence(builder.Configuration);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        

        builder.Services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCustomExceptionHandler();

        app.UseHttpsRedirection();

        app.MapControllers();

        await app.SeedSampleDataAsync();

        app.Run();
    }
}
