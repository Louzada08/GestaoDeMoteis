using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Interfaces.Repositories;
using GestaoMotel.Domain.Interfaces.Services;

namespace GestaoMotel.Domain.DomainServices;

public class PriceTableTimeService : IPriceTableTimeService
{
    private readonly IPriceTableTimeRepository _repository;
    public PriceTableTimeService(IPriceTableTimeRepository repository)
    {
        _repository = repository;
    }

    public async Task<PriceTableTime> Create(PriceTableTime priceTime)
    {
        var ret = _repository.Add(priceTime);
        await _repository.UnitOfWork.Commit();

        return ret;
    }

    //public async Task<IList<PriceTable>> GetAll(PriceTableFilter filter, bool @readonly = false)
    //{
    //    var filterQuery = await _repository.QueryableFor(f =>
    //            (filter.CategoryId.Equals(f.CategoryId)))
    //            .Apply(filter)
    //            .AsNoTracking()
    //            .OrderBy(o => o.TypePrice)
    //            .ToListAsync();

    //    return filterQuery;
    //}

    //public Task<PriceTable> GetById(Guid? id)
    //{
    //    throw new NotImplementedException();
    //}

}
