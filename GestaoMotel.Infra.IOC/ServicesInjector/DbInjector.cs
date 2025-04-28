using GestaoMotel.Domain.Interfaces.Repositories;
using GestaoMotel.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoMotel.Infra.IoC.ServicesInjector;

public static class DbInjector
{
    public static IServiceCollection AddDbInjector(this IServiceCollection services)
    {
        services.AddScoped<ISuiteRepository, SuiteRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IPriceTableRepository, PriceTableRepository>();
        services.AddScoped<IPriceTableTimeRepository, PriceTableTimeRepository>();

        return services;
    }
}
