using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Interfaces.Repositories;
using GestaoMotel.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;


namespace GestaoMotel.Domain.DomainServices;

public class CommandService : ICommandService
{
    private readonly IServiceCommandRepository _repository;
    public CommandService(IServiceCommandRepository repository)
    {
        _repository = repository;
    }

    public Task<ServiceCommand> Create(ServiceCommand srvCommand)
    {
        throw new NotImplementedException();
    }

    public Task Delete(ServiceCommand srvCommand)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<ServiceCommand>> GetAll()
    {
        var filterQuery =  await _repository.QueryableFor()
                .AsNoTracking()
                .Include(p => p.Suite)
                .OrderBy(o => o.Id) 
                .ToListAsync();

        return filterQuery;
    }

    public async Task<ServiceCommand> GetById(Guid id)
    {
        var queryCommand = await _repository.QueryableFor(p => p.Id.Equals(id))
            .FirstOrDefaultAsync();

        if (queryCommand == null) throw new Exception("Customer not found");

        return queryCommand;
    }

    public Task<ServiceCommand> Update(ServiceCommand srvCommand)
    {
        throw new NotImplementedException();
    }
}
