using GestaoMotel.Domain.Entities;

namespace GestaoMotel.Domain.Interfaces.Services;

public interface ICommandService
{
    Task<IList<ServiceCommand>> GetAll();
    Task<ServiceCommand> GetById(Guid id);
    Task<ServiceCommand> Create(ServiceCommand srvCommand);
    Task<ServiceCommand> Update(ServiceCommand srvCommand);
    Task Delete(ServiceCommand srvCommand);
}
