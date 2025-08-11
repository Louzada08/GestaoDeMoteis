using GestaoMotel.Application.Services;
using GestaoMotel.Domain.DesignPatterns.Observers;
using GestaoMotel.Domain.DomainServices;
using GestaoMotel.Domain.Interfaces.DesignPatterns.Observers;
using GestaoMotel.Domain.Interfaces.Services;
using GestaoMotel.Infra.Data;
using GestaoMotel.Infra.Jwt;
using GestaoMotel.Infra.WorkServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GestaoMotel.Infra.IoC.ServicesInjector;

public static class ServicesInjector
{
    public static IServiceCollection AddServicesInjectors(this IServiceCollection services)
    {
        
        services.AddScoped<AppDbContext>();
        services.AddScoped<ISuiteService, SuiteService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IPriceTableService, PriceTableService>();
        services.AddScoped<IPriceTableTimeService, PriceTableTimeService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddSingleton<ILogger, Logger<CheckLengthOfStayHostedService>>();
        services.AddScoped<ICalculatePermanence, CalculatePermanence>();
        services.AddScoped<ICommandService, CommandService>();
        services.AddTransient<ISubject, Subject>();

        return services;
    }
}