using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Filters;

namespace GestaoMotel.Domain.Interfaces.Services;

public interface IPriceTableService
{
    Task<List<PriceTable>> GetAll(ServiceCommand comanda);
    Task<PriceTable> GetById(Guid? id);
    Task<PriceTable> Create(PriceTable priceTable);
    Task<PriceTable> Update(PriceTable priceTable);
    Task Delete(PriceTable priceTable);
}
