using D2.Data;
using D2.Data.Entities;
using D2.Data.Repositories;

namespace D2.Services;
public interface ICategoryService
{
    public Task<IList<Category>> GetAllAsync();
    public Task<Category?> GetOneAsync(int id);
    public Task<Category?> AddAsync(Category entity);
    public Task<Category?> EditAsync(Category entity);
    public Task RemoveAsync(int id);
}
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public Task<Category?> AddAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    public Task<Category?> EditAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Category>> GetAllAsync()
    {
        var data = await _repository.GetAllIncludedAsync();
        return data.ToList();
    }

    public Task<Category?> GetOneAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(int id)
    {
        throw new NotImplementedException();
    }
}