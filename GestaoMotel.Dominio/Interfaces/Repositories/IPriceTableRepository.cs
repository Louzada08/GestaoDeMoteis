using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Entities.Base;

namespace GestaoMotel.Domain.Interfaces.Repositories;

public interface IPriceTableRepository : IBaseRepository<PriceTable>, IAggregateRoot
{
}
