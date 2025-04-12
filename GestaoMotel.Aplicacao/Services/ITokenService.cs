
using GestaoMotel.Domain.Entities;

namespace GestaoMotel.Application.Services;

public interface ITokenService
{
    Task<AppUserResponseLogin> ToGenerateJwt(string email);
}
