using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Configuration;

namespace NSE.WebApp.MVC.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient,
                       IOptions<AppSettings> settings)
    {
        httpClient.BaseAddress = new Uri(settings.Value.WebAppUrl);

        _httpClient = httpClient;
    }

    // Implemente os métodos da interface IAuthService
}