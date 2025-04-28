using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Filters;

namespace GestaoMotel.Domain.Interfaces.Services;

public interface ICategoryService
{
    Task<IList<Category>> GetAll(CategoryFilter categoryFilter, bool @readonly = false);
    Task<Category> GetById(Guid? id);
    Task<Category> Create(Category category);
    Task<Category> Update(Category category);
    Task Delete(Category category);
}
