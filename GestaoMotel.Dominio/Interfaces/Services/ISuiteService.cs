using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Filters;

namespace GestaoMotel.Domain.Interfaces.Services;

public interface ISuiteService
{
    Task<IList<Suite>> GetAll(SuiteFilter suiteFilter, bool @readonly = false);
    Task<Suite> GetById(Guid id);
    Task<Suite> Create(Suite suite);
    Task<Suite> Update(Suite suite);
    Task Delete(Suite suite);
}
