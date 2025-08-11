//using GestaoMotel.Domain.Entities;
//using GestaoMotel.Domain.Interfaces.Services;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using Microsoft.VisualBasic;

//namespace GestaoMotel.Application.Services;

//public class CheckLengthOfStayBackgroundService(ILogger<CheckLengthOfStayBackgroundService> _logger, 
//    ICommandService comandas) : BackgroundService
//{
//    //public CheckLengthOfStayBackgroundService(ICalculatePermanence permanence, 
//    //    ILogger<CheckLengthOfStayBackgroundService> logger)
//    //{
//    //    _permanence = permanence;
//    //    _logger = logger;
//    //}

//    public async Task<bool> GetTable(IList<ServiceCommand> msg)
//    {
//        var a = 0;
//        foreach (ServiceCommand comds in msg)
//        {
//            _logger.LogInformation("Comanda: {0} / Suite: {1}", comds.Id, comds.SuiteId);
//        }
//        return await Task.FromResult(true);
//    }

//    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//    {
//        while (!stoppingToken.IsCancellationRequested)
//        {
//            var msg = await comandas.GetAll();
//            await GetTable(msg);
//            await GeraLogger(stoppingToken);
//            await Task.Delay(TimeSpan.FromSeconds(20), stoppingToken);
//        }
//    }

//    private async Task GeraLogger(CancellationToken stoppingToken)
//    {
//        _logger.LogInformation("Calculo tempo de permanencia iniciado em: {time}", DateTimeOffset.Now);
//        while (!stoppingToken.IsCancellationRequested)
//        {
//            _logger.LogInformation("Executando serviço em segundo plano: {time}", DateTimeOffset.Now);
//        }

//        _logger.LogInformation("Background Service finalizado em: {time}", DateTimeOffset.Now);
//    }
//}
