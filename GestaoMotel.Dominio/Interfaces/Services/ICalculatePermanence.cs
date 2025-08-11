using GestaoMotel.Domain.Entities;

namespace GestaoMotel.Domain.Interfaces.Services;

public interface ICalculatePermanence
{
    Task<bool> GetTable(ServiceCommand serviceCommand);
}