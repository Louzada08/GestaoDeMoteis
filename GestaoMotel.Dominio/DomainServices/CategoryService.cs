using GestaoMotel.Domain.Entities;
using GestaoMotel.Domain.Filters;
using GestaoMotel.Domain.Interfaces.Repositories;
using GestaoMotel.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;


namespace GestaoMotel.Domain.DomainServices;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Category> Create(Category category)
    {
        var ret = _repository.Add(category);
        await _repository.UnitOfWork.Commit();

        return ret;
    }

    public Task Delete(Category suite)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Category>> GetAll(CategoryFilter categoryFilter, bool @readonly = false)
    {
        throw new NotImplementedException();
    }

    public async Task<Category> GetById(Guid? id)
    {
        var queryCategory = await _repository.QueryableFor(p => p.Id.Equals(id))
            .FirstOrDefaultAsync();

        if (queryCategory == null) throw new Exception("Category not found");

        return queryCategory;
    }

    public Task<Category> Update(Category suite)
    {
        throw new NotImplementedException();
    }
}
