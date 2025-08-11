using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Filters;
using GestaoMotel.Domain.Interfaces.Repositories;
using GestaoMotel.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;


namespace GestaoMotel.Domain.DomainServices;

public class SuiteService : ISuiteService
{
    private readonly ISuiteRepository _repository;
    public SuiteService(ISuiteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Suite> Create(Suite suite)
    {
        var ret = _repository.Add(suite);
        await _repository.UnitOfWork.Commit();

        return ret;
    }

    public Task Delete(Suite suite)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Suite>> GetAll(SuiteFilter suiteFilter, bool @readonly = false)
    {
        throw new NotImplementedException();
    }

    public async Task<Suite> GetById(Guid id)
    {
        var querySuite = await _repository.QueryableFor(p => p.Id.Equals(id))
            .FirstOrDefaultAsync();

        if (querySuite == null) throw new Exception("Customer not found");

        return querySuite;
    }

    public Task<Suite> Update(Suite suite)
    {
        throw new NotImplementedException();
    }
}
