using GestaoMotel.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace GestaoMotel.Domain.DomainServices;

public class CheckLengthOfStayMiddleware
{
    private readonly RequestDelegate _next;

    public CheckLengthOfStayMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, ICalculatePermanence _checkService)
    {

        try
        {
           // await _checkService.GetTable(_priceTableFilter);
            //await _checkService.GetTable(stoppingToke);
            await _next(context);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}
