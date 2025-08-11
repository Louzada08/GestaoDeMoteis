using GestaoMotel.Domain.Mediator.Interfaces;
using GestaoMotel.Domain.Mediator;
using GestaoMotel.Domain.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using GestaoMotel.Application.Commands.Suites.Requests;
using GestaoMotel.Application.Commands.Suites.Handlers;
using GestaoMotel.Application.Commands.Categorys.Handlers;
using GestaoMotel.Application.Commands.Categorys.Requests;
using GestaoMotel.Application.Commands.TablePrices.Requests;
using GestaoMotel.Application.Commands.TablePrices.Handlers;

namespace GestaoMotel.Infra.IoC.ServicesInjector;

public static class MediatorInjector
{
    public static IServiceCollection AddMediatorInjector(this IServiceCollection services)
    {
        services.AddScoped<IMediatorHandler, MediatorHandler>();

        services.AddScoped<IRequestHandler<CreateSuiteRequest, ValidationResultBag>, SuiteCommandHandler>();

        services.AddScoped<IRequestHandler<CreateCategoryRequest, ValidationResultBag>, CategoryCommandHandler>();

        services.AddScoped<IRequestHandler<CreatePriceTableRequest, ValidationResultBag>, PriceTableCommandHandler>();
        services.AddScoped<IRequestHandler<CreatePriceTableTimeRequest, ValidationResultBag>, PriceTableCommandHandler>();

        return services;
    }
}