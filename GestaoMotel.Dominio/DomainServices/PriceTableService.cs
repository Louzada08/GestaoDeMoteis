using AspNetCore.IQueryable.Extensions;
using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Filters;
using GestaoMotel.Domain.Interfaces.Repositories;
using GestaoMotel.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace GestaoMotel.Domain.DomainServices;

public class PriceTableService : IPriceTableService
{
    private readonly IPriceTableRepository _repository;
    public PriceTableService(IPriceTableRepository repository)
    {
        _repository = repository;
    }

    public async Task<PriceTable> Create(PriceTable priceTable)
    {
        var ret = _repository.Add(priceTable);
        await _repository.UnitOfWork.Commit();

        return ret;
    }

    public Task Delete(PriceTable priceTable)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PriceTable>> GetAll(ServiceCommand comanda)
    {
        
        var filterQuery = await _repository.QueryableFor(f =>
                (comanda.Suite.CategoryId.Equals(f.CategoryId)))
            //    .Apply(filter)
                .AsNoTracking()
                .Include(p => p.PriceTableTimes.OrderBy(pt => pt.RuleOrder))
                .OrderBy(o => o.TypePrice)
                .ToListAsync();

        return filterQuery;
    }

    public Task<PriceTable> GetById(Guid? id)
    {
        throw new NotImplementedException();
    }

    public Task<PriceTable> Update(PriceTable priceTable)
    {
        throw new NotImplementedException();
    }
}
