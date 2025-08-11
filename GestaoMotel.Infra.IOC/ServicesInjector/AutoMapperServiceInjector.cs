using AutoMapper;
using ArqLimpaDDD.Mapping.AutoMapperProfiles;
using Microsoft.Extensions.DependencyInjection;
using GestaoMotel.Mapping.AutoMapperProfiles;


namespace GestaoMotel.Infra.IoC.ServicesInjector;
public static class AutoMapperServiceInjector
{
    public static IServiceCollection AddAutoMapperInjector(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new SuiteProfile());
            mc.AddProfile(new CategoryProfile());
            mc.AddProfile(new PriceTableProfile());
            mc.AddProfile(new PriceTableTimeProfile());
        });

        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}
