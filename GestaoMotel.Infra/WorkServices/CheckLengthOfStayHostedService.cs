using GestaoMotel.Domain.Enums;
using GestaoMotel.Domain.Interfaces.Services;
using GestaoMotel.Infra.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GestaoMotel.Infra.WorkServices;

public class CheckLengthOfStayHostedService : IHostedService, IDisposable
{
    private readonly IServiceScopeFactory _scopedFactory;
    private readonly ILogger<CheckLengthOfStayHostedService> _logger;
    private Timer? _timer;

    public CheckLengthOfStayHostedService(ILogger<CheckLengthOfStayHostedService> logger,
        IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopedFactory = scopeFactory;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(ExecutarTarefa, null, TimeSpan.Zero, TimeSpan.FromSeconds(45));
        //   _calculate.GetTable(_priceTableTime);
        return Task.CompletedTask;

    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Hosted Service encerrado.");
        return Task.CompletedTask;
    }
    public void Dispose()
    {
        _logger.LogInformation("Hosted Service limpo e descartado.");
    }

    private void ExecutarTarefa(object? state)
    {
        using var scope = _scopedFactory.CreateAsyncScope();
        var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var commandService = scope.ServiceProvider.GetRequiredService<ICommandService>();
        var calculate = scope.ServiceProvider.GetRequiredService<ICalculatePermanence>();
        _logger.LogInformation("Hosted Service iniciado.");
        var comanda = commandService.GetAll().Result;
        if (comanda is not null)
        {
            _logger.LogInformation("Hosted Service iniciado: {0}", comanda.FirstOrDefault().Id);
            calculate.GetTable(comanda.FirstOrDefault(c => c.Suite.StateSuite.Equals(StateSuiteEnum.Busy)));
        }
    }
}
