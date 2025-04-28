using GestaoMotel.Application.Services;
using GestaoMotel.Domain.DomainServices;
using GestaoMotel.Domain.Interfaces.Services;
using GestaoMotel.Infra.Data;
using GestaoMotel.Infra.Jwt;
using Microsoft.Extensions.DependencyInjection;

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

        return services;
    }
}