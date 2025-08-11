using GestaoMotel.Domain.Entities;

namespace GestaoMotel.Domain.Interfaces.Services;

public interface IPriceTableTimeService
{
    Task<PriceTableTime> Create(PriceTableTime priceTable);
}
