using GestaoMotel.Domain.DomainServices;

namespace GestaoMotel.API.Configuration.Middleware;

public static class CheckLengthOfStayMiddlewareExtensions
{
    public static IApplicationBuilder UseCustomLengthAndStayMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CheckLengthOfStayMiddleware>();
    }
}
