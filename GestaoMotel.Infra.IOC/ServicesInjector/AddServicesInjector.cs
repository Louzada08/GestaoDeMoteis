using GestaoMotel.Application.Services;
using GestaoMotel.Domain.Mediator;
using GestaoMotel.Domain.Mediator.Interfaces;
using GestaoMotel.Infra.Data;
using GestaoMotel.Infra.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoMotel.Infra.IoC.ServicesInjector;

public static class AddServicesInjector
{
    public static IServiceCollection AddServicesInjectors(this IServiceCollection services)
    {
        services.AddScoped<AppDbContext>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IMediatorHandler, MediatorHandler>();

        return services;
    }
}