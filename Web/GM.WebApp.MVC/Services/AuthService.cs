using GestaoMotel.Domain.Messages.Communication;
using GM.WebApp.MVC.Extensions;
using GM.WebApp.MVC.Models;
using Microsoft.Extensions.Options;

namespace GM.WebApp.MVC.Services
{
    public interface IAuthService
    {
        Task<UserResponseLogin> Login(UserLogin usuarioLogin);

        Task<UserResponseLogin> Registro(UserRegistration usuarioRegistro);
    }

    public class AuthService : Service, IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient,
                                   IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.WebAppUrl);

            _httpClient = httpClient;
        }

        public async Task<UserResponseLogin> Login(UserLogin usuarioLogin)
        {
            var loginContent = ObterConteudo(usuarioLogin);

            var response = await _httpClient.PostAsync("/api/Auth/sigin", loginContent);

            if (!TratarErrosResponse(response))
            {
                return new UserResponseLogin
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializarObjetoResponse<UserResponseLogin>(response);
        }

        public async Task<UserResponseLogin> Registro(UserRegistration usuarioRegistro)
        {
            var registroContent = ObterConteudo(usuarioRegistro);

            var response = await _httpClient.PostAsync("/api/identidade/nova-conta", registroContent);

            if (!TratarErrosResponse(response))
            {
                return new UserResponseLogin
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializarObjetoResponse<UserResponseLogin>(response);
        }
    }

}
